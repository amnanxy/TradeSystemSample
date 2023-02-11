金流系統 sample code

會碰到的情境: 有促銷活動時開賣當下會有瞬間大流量(例如雙11)  

Service 套 PreconditionDecorator 的目的: 將大量的檢查抽離核心邏輯  

Repository 套 CacheDecorator 的目的: 降低 DB 負擔，因快取只針對當次的 Http Request，所以生命週期是註冊成 InstancePerLifetimeScope  

與真實狀況之差異:  
1. 單據種類有數種，這邊僅用交易單(Trade)做範例  
2. 金流依據種類不同在細部的檢查會有些差異，這邊僅以單一種類做範例  
