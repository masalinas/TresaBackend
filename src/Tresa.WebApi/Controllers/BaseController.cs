using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

using Tresa.Services.Contracts;

namespace Tresa.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : class
    {
        protected readonly IBaseService<T> service;
        protected readonly ILogger<BaseController<T>> logger;

        public BaseController(IBaseService<T> service,
                              ILogger<BaseController<T>> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<T> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public T Get(long id)
        {
            return this.service.Get(id);
        }

        private Expression GetExpressionWhere(ParameterExpression argParam, JToken where)
        {
            Expression expression = Expression.Constant(true);

            List<Expression> expressions = new List<Expression>();

            if (where != null)
            {
                foreach (JObject item in where)
                {
                    JProperty property = item.Properties().First<JProperty>();

                    var add = Expression.Equal(Expression.Property(argParam, property.Name),
                                               Expression.Convert(Expression.Constant(((JValue)property.Value).Value), ((JValue)property.Value).Value.GetType()));

                    expressions.Add(add);
                }

                if (expressions.Count > 1)
                {
                    Expression addExpression = expressions[0];

                    for (var i = 0; i < expressions.Count - 1; i++)
                    {
                        addExpression = Expression.And(addExpression, expressions[i + 1]);
                    }

                    expression = addExpression;
                }
                else
                {
                    expression = expressions[0];
                }
            }

            return expression;
        }

        private string[] GetArrayInclude(JToken include)
        {
            List<string> includes = new List<string>();

            if (include != null) {
                foreach (JObject item in include)
                {
                    JProperty property = item.Properties().First<JProperty>();

                    includes.Add(((JValue)property.Value).Value.ToString());
                }
            }

            return includes.ToArray();
        }

        private List<Expression<Func<T,object>>> GetArrayOrder(JToken order)
        {
            List<Expression<Func<T,object>>> expressions = new List<Expression<Func<T,object>>>();

            if (order != null)
            {
                foreach (string item in order)
                {
                    string[] tokens = item.Split(" ");
                    string property = tokens[0];
                    string direction = tokens[1];

                    if (direction == "ASC") 
                    {
                        var type = typeof(T);
                        var propertyType = type.GetProperty(property);
                        var parameter = Expression.Parameter(type);
                        var access = Expression.Property(parameter, propertyType);
                        //var convert = Expression.Convert(access, typeof(object));
                        var function = Expression.Lambda<Func<T,object>>(access, parameter);

                        expressions.Add(function);
                    }
                    else if (direction == "DESC") 
                    {
                        //orders.Add(item);
                    }                    
                }
            }

            return expressions;
        }

        private string[] GetArrayField(JToken field)
        {
            List<string> fields = new List<string>();

            if (field != null)
            {
                foreach (string item in field)
                {
                    fields.Add(item);
                }
            }

            return fields.ToArray();
        }

        [HttpGet("{filter}/find")]
        public IEnumerable<T> Find(string filter)
        {
            //{"where": [{"DeviceId": 1},{"Version": "V1"}]}
            //{"where": [{"DeviceId": 1},{"Version": "V1"}], "include": [{"relation": "Tests"}]}

            JObject filterObject = JObject.Parse(filter);

            JToken whereToken = filterObject["where"];
            JToken includeToken = filterObject["include"];
            JToken orderToken = filterObject["order"];
            JToken fieldToken = filterObject["fields"];            
            JToken skipToken = filterObject["skip"];
            JToken limitToken = filterObject["limit"];

            // STEP01: get Where Predicate
            ParameterExpression argParam = Expression.Parameter(typeof(T), "p");
            Expression expression = GetExpressionWhere(argParam, whereToken);

            var predicates = Expression.Lambda<Func<T, bool>>(expression, argParam);

            // STEP02: get Includes
            var includes = GetArrayInclude(includeToken);

            // STEP03: get Orders
            var orders = GetArrayOrder(orderToken);

            // STEP04: get Fields
            var fields = GetArrayField(fieldToken);

            return this.service.Find(predicates, includes, orders, fields);
        }

        [HttpPost]
        public T Add([FromBody] T test)
        {
            T result = this.service.Add(test);
            this.service.SaveChanges();

            return result;
        }

        [HttpPut]
        public T Update([FromBody] T test)
        {
            T result = this.service.Update(test);
            this.service.SaveChanges();

            return result;
        }

        [HttpDelete]
        public T Remove([FromBody] T test)
        {
            T result = this.service.Remove(test);
            this.service.SaveChanges();

            return result;
        }
    }
}
