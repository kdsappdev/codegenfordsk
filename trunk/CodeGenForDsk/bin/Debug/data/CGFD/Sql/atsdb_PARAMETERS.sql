
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('风险管理','revaluation_rate','M','重估价设置',3,'M手动，R自动','PINGO','S','RevaluationRate','ADBCHOICES','N');
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('交易管理','IsBranch','Y','交易模式',1,'Y总分交易模式,N银行间交易模式','PINGO','S',NULL,'BOOL','Y');
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('MarginParameters','NettingAmount','20,000,000.',NULL,0,'TEST1','PINGO','C',NULL,NULL,NULL);
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('MarginParameters','ExchangeRateFactor','V',NULL,0,'TEST2','PINGO','C',NULL,NULL,NULL);
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('MarginParameters','CreditFactor','2.',NULL,0,'TEST3','PINGO','C',NULL,NULL,NULL);
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('MarginParameters','Tolerance','0.1',NULL,0,NULL,'PINGO','C',NULL,NULL,NULL);
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('MarginParameters','InitialMarginFormula','(Netting Amount)*RF*CF*2*(1+Tolerance)',NULL,NULL,NULL,'PINGO','C',NULL,NULL,NULL);
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('MarginParameters','VariationMarginFormula','MAX((sum(abs(Netting Amount))-(Netting Amount))*(Rate Factor),0)',NULL,NULL,NULL,'PINGO','C',NULL,NULL,NULL);
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('风险管理','PostCreditChecking','Y','额度模块',1,'Y启用额度模块,N不启用额度模块','PINGO','S',NULL,'BOOL','N');
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('风险管理','conversion_rate','R','折算率设置',2,'M手动,R自动','PINGO','S','ConversationRate','ADBCHOICES','N');
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('风险管理','CreditLimitCheckDays','30','额度到期提醒',4,'额度到期提醒检查天数','PINGO','S',NULL,'UINT','N');
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('交易管理','ForwardDealCheckDays','30','远期交易到期提醒',2,'远期交易到期提醒检查天数','PINGO','S',NULL,'UINT','N');
Insert into PARAMETERS(TITLE,PARAMETER_NAME,PARAMETER_VALUE,LABEL_NAME,PARAMETER_ORDER,COMMENTS,LOCATION,PARAMETERTYPE,PARAMETERVALUEKEY,PARAMETERVALUETYPE,PARAMETERVALUEREADONLY) Values('牌价管理','SendServiceName','CALPUB','服务名称',1,'配置权重处理后需要发布到哪一个服务名称上','PINGO','S',NULL,'TEXT','Y');
