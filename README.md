# Ja3HttpClient
用besthttp魔改支持c#模拟ja3指纹的httpclient <br>
TLSVersion,Ciphers,Extensions,EllipticCurves,EllipticCurvePointFormats <br>
其中可以修改:Ciphers,EllipticCurves,EllipticCurvePointFormats <br>
Extensions：支持随机排序，理论上也可以改，但是不太了解协议改了可能出问题 <br>
支持windows系统，其它平台理论上也支持，没有做过测试 <br>
主要参照了wormfox大神的文章 [原创C# 使用BouncyCastle加密套件实现自定义Ja3指纹代码](https://bbs.kanxue.com/thread-277354.htm )  <br>
还有  [HTTPS 温故知新（六） —— TLS 中的](https://halfrost.com/https-extensions/) <br>
# 最重要的是BestHttp是unity的付费插件 该项目仅作学习使用，希望大家支持正版  <br>
dotnet在3之后的版本httpclient支持在非windows平台修改TlsCiphers,是否可以通过修改HttpClient的sslstream来支持模拟ja3指纹？
