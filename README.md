# 你的专属错题本
## 本项目使用c# docker 微服务架构设计思想 搭建错题本应用。
> [!NOTE]
>
> 我的.net 版本为 7.0 因此我的全部nuget包适配的版本为7.0版本
> 
> 这个项目主要使用了 EFcore自动生成数据库  Dapr  网关技术  **领域驱动设计**  时间总线（rabbitmq） 微服务相关的身份验证  token穿透等相关技术
> 
> [本项目参考于我的老师.net 8.0版本的项目]( https://gitee.com/zhangyin-gitee/rec-all-dapr-2)
>
> 

## 目录结构
### Contrib
#### 1.textitem
+ commands文件夹创建了post get请求需要的格式要求
+ controller 文件夹负责存放controller的相关代码 进行增删改查操作 以及集成时间总线，itemid存储的相关实现
+ filters 定义了与身份验证的相关过滤信息
+ IntegrationEvents 定义了与集成事件原型属性的
+ Migrations 是EF core自动生成数据库生成的数据库相关配置文件夹
+ models 进行了文本文件模型的创建
+ services TextItemContent 负责创建关于textitem的数据库 iiddentityservice定义负责进行用户唯一标识符的认证的接口 iddentityservice实现了用户唯一标识符的认证 mockeridentityservice负责进行数据库链接密钥（暂时版）
+ viewmodels 定义了进行controller操作时候UI页面的返回参数信息
+ programextensions 对于program 部分操作进行了扩展操作，使program程序变得简洁
+ appsetting.json 存储了与本项目相关的内部网关链接
#### 2.maskedtextitem
> [!NOTE]
>
> 与上述相同 只是model多了一个string类型的maskcontent属性

### Core
+ 创建list 进行list->set->item 的三层数据操作
+ Domain 引用了Infrastructure/ddd.domain 实现了对于聚合根相关的定义
+ aggregatemodels： 进行了list的增删改的定义实现
+ Listtype中定义了两种类型错题的格式
+ events 定义了领域驱动设计相关的事件
+ exceptions  定义了异常类
+ Infrastructure 进行了list set item事件类型数据库的自动创建
+ API 部分是整个领域驱动设计的核心 
### dapr
+ 进行了dapr的相关定义配置 其中实现消息总线 数据库链接字符串的隐藏
### Infrastructure
+ Ddd.domain 进行了与领域驱动设计的初步设计 其中定义了报错信息  实体 枚举 数据根的相关操作
+ Ddd.infrastructure 进行了对domain的实现
+ EventBus 定义了消息总线
+ Identity 这个部分 关于用户的身份验证 以及token的穿透 需要将maskeditem中的scope注册其中
+ infrastructure.api 这个部分与dapr健康检查以及身份验证相关 
+ integrationeventlog 定义了一些集成事件的日志
+ servicesStatus 定义了与健康检查的相关操作，健康检查各大容器的目前状态

