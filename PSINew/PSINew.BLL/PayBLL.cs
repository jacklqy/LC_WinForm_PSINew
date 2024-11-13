using Common;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
       public  class PayBLL
        {
                /// <summary>
                /// 进入付款页面,获取付款 列表
                /// </summary>
                /// <param name="payType"></param>
                /// <returns></returns>
                public List<PayInfoModel> GetFirstPayInfos(string payType, string strPayFor)
                {
                        List<PayInfoModel> payList = new List<PayInfoModel>();
                        string types = "现金,银行卡,微信,支付宝";
                        List<string> list = types.GetStrList(',', false);
                        int id = 0;

                        if (!string.IsNullOrEmpty(strPayFor))
                        {
                                List<string> listPayFor = strPayFor.GetStrList(';', false);
                                foreach (string str in list)
                                {
                                        id += 1;
                                        decimal money = 0;
                                        foreach (var spf in listPayFor)
                                        {
                                                if (spf.Split(' ')[0] == str)
                                                {
                                                        money = spf.Split(' ')[1].GetDecimal();
                                                        break;
                                                }
                                        }
                                        payList.Add(new PayInfoModel()
                                        {
                                                PayId = id,
                                                PayName = str,
                                                PayMoney = money,
                                                PayType = payType
                                        });
                                }
                        }
                        else
                        {
                                foreach (string str in list)
                                {
                                        id += 1;
                                        payList.Add(new PayInfoModel()
                                        {
                                                PayId = id,
                                                PayName = str,
                                                PayMoney = 0,
                                                PayType = payType
                                        });
                                }
                        }

                        return payList;
                }
        }
}
