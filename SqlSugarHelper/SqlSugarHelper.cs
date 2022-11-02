using System;
using SqlSugar;

namespace Helper
{
    public class SqlSugarHelper //不能是泛型类
    {
        public static SqlSugarScope db = new SqlSugarScope(
                      new ConnectionConfig()
                      {
                          //sql连接字符串
                          ConnectionString = "server=127.0.0.1;user id=root;password=O9Z9nhPtoO0KEt2f;database=identity",
                          //数据库类型
                          DbType = DbType.MySql,
                          //自动关闭连接
                          IsAutoCloseConnection = true,
                          //错误显示的语言
                          LanguageType = LanguageType.Chinese,//中文错误
                                                              //全局配置
                          ConfigureExternalServices = new ConfigureExternalServices
                          {
                              EntityNameService = (type, entity) =>
                              {
                                  //所有实体生效的配置
                                  entity.IsDisabledDelete = true;//禁止删除表结构
                                                                 // entity.IsDisabledUpdateAll = true;//禁止更新表结构
                              }
                          },
                          //事件
                          AopEvents = new AopEvents
                          {
                              //sql执行报错
                              OnError = (err) =>
                              {
                                  Console.WriteLine($"错误:{err}");
                              },
                              //sql执行前
                              OnLogExecuting = (sql, pars) =>
                              {
                              },
                              //sql执行后
                              OnLogExecuted = (sql, pars) =>
                              {
                              },
                              //sql执行前可以做修改的回调
                              OnExecutingChangeSql = (sql, pars) =>
                              {
                                  //sql=newsql
                                  //foreach(var p in pars) //修改
                                  return new KeyValuePair<string, SugarParameter[]>(sql, pars);
                              },
                              DataExecuting = (oldValue, entity) =>
                              {
                                  /*** inset生效 ***/
                                  if (entity.PropertyName == "CreateTime" && entity.OperationType == DataFilterType.InsertByObject)
                                  {
                                      entity.SetValue(DateTime.Now);//修改CreateTime字段
                                                                        //entityInfo有字段所有参数
                                  }

                                  if (entity.PropertyName == "LogicId" && entity.OperationType == DataFilterType.InsertByObject)
                                  {
                                      entity.SetValue( Guid.NewGuid().ToString("N"));//修改CreateTime字段
                                                                    //entityInfo有字段所有参数
                                  }

                                  /*** updatet生效 ***/
                                  if (entity.PropertyName == "UpdateTime" && entity.OperationType == DataFilterType.UpdateByObject)
                                  {
                                      entity.SetValue(DateTime.Now);//修改UpdateTime字段
                                  }

                              }
                          }
                      }

                 );
    }
}