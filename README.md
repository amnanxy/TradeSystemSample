金流系統 sample code

會碰到的情境：有促銷活動時開賣當下會有瞬間大流量(例如雙11)  

Service 套 PreconditionDecorator 的目的：將大量的檢查抽離核心邏輯  

Repository 套 CacheDecorator 的目的：降低 DB 負擔，因快取只針對當次的 Http Request，所以生命週期是註冊成 InstancePerLifetimeScope  

與真實狀況之差異  
1. 單據種類有數種，這邊僅用交易單(Trade)做範例  
2. 金流依據金流種類不同在檢查上會有些差異，這邊僅以單一種類做範例  

名詞解釋  
1. Payed：已付款  
2. Captured：已請款  
3. Refunded：已退款  
