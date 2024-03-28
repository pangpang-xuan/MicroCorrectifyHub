# 你的专属错题本
## 本项目使用c# docker 微服务架构设计思想 搭建错题本应用。

## 目录结构
### Contrib
+ commands文件夹创建了post get请求需要的格式要求
+ controller 文件夹负责存放controller的相关代码 进行增删改查操作
+ models 进行了文本文件模型的创建
+ services TextItemContent 负责创建关于textitem的数据库 iddentityservice负责进行用户唯一标识符的认证 mockeridentityservice负责进行数据库链接密钥
+ viewmodels 定义了进行controller操作时候页面的返回值
+ programextensions 对于program 部分操作进行了扩展操作，使program程序变得简洁
### Core
+ 创建list 进行list->set->item 的三层数据操作
+ 定义了异常类
+ event： 以及list创建和删除的相关事件
+ aggregatemodels： 进行了list的增删改的定义实现
### dapr
+ 进行了dapr的相关定义配置
### Infrastructure
+ servicesStatus 定义了与健康检查的相关操作，健康检查各大容器的目前状态
+ infrastructure.api 进行了与健康检查操作的相关边车的操作
+ ddd.domain 进行了与领域驱动设计的初步设计 其中定义了报错信息  实体 枚举 数据根的相关操作

