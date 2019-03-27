DROP TABLE dbo.TB_BUYER;
DROP TABLE dbo.TB_RIDER;
DROP TABLE dbo.TB_SELLER;
DROP TABLE dbo.TB_ORDER;
DROP TABLE dbo.TB_GOODS;
DROP TABLE dbo.TB_CART;
DROP TABLE dbo.TB_SHOP;
DROP TABLE dbo.TB_ADMIN;
DROP TABLE [dbo].[TB_EVALUATE_RIDER];
DROP TABLE TB_EVALUATE_GOODS;
DROP TABLE [dbo].[TB_ORDER_DETAILS];
DROP TABLE [dbo].[TB_FLOW];
DROP TABLE dbo.TB_BUYER_COLLECT;
DROP TABLE dbo.TB_LOG;

CREATE TABLE TB_ADMIN
    (
      --管理员表
      ADMIN_ID VARCHAR(20) PRIMARY KEY
                           NOT NULL ,	--ID 账号
      ADMIN_PWD VARCHAR(20) NOT NULL,				--PWD 密码
    )

CREATE TABLE TB_BUYER
    (
      --个人信息表-买家表
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--BUYER_ID ID INT
      ACCOUNT VARCHAR(20) NOT NULL ,			--ACCOUNT 账号 VARCAHR
      PWD VARCHAR(20) NOT NULL ,				--PWD 密码 VARCHAR
      BUYER_NAME VARCHAR(20) ,		--BUYER_NAME 昵称 VARCHAR
      BUYER_ADDRESS VARCHAR(100) ,	--BUYER_ADDRESS 收货地址 VARCHAR
      BUYER_TEL VARCHAR(11) ,			--BUYER_TEL 联系电话 VARCHAR 
      PERMISSIONS BIT DEFAULT ( 1 ) ,			--PERMISSIONS 权限 VARCHAR
      BUYER_IMAGE_URL VARCHAR(100)	--BUYER_IMAGE_URL 买家头像路径
    )

CREATE TABLE TB_SELLER
    (
      --个人信息表-卖家表
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--ID ID INT
      ACCOUNT VARCHAR(20) NOT NULL ,			--ACCOUNT 账号 VARCAHR
      PWD VARCHAR(20) NOT NULL ,				--PWD 密码 VARCHAR
      SELLER_NAME VARCHAR(20) ,		--SELLER_NAME 昵称 VARCHAR
      SHOP_ID INT ,					--SHOP_ID 店铺号 VARCHAR
      BUYER_ADDRESS VARCHAR(100) ,	--BUYER_ADDRESS 收货地址 VARCHAR
      BUYER_TEL VARCHAR(11) ,			--BUYER_TEL 联系电话 VARCHAR (公用)
      PERMISSIONS BIT DEFAULT ( 1 ) ,				--PERMISSIONS 权限 VARCHAR
      SELLER_IMAGE_URL VARCHAR(100) 	--SELLER_IMAGE_URL 卖家头像路径
    )

CREATE TABLE TB_RIDER
    (
      --个人信息-骑手表
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--ID ID INT
      ACCOUNT VARCHAR(20) NOT NULL ,			--ACCOUNT 账号 VARCAHR
      PWD VARCHAR(20) NOT NULL ,				--PWD 密码 VARCHAR
      RIDER_NAME VARCHAR(20) , 				--RIDER_NAME VARCHAR 昵称 
      BUYER_ADDRESS VARCHAR(100) ,				--BUYER_ADDRESS VARCHAR 地址
      BUYER_TEL VARCHAR(11) ,					--BUYER_TEL VARCHAR（公用）电话
      PERMISSIONS BIT DEFAULT ( 1 ) ,				--PERMISSIONS 权限 VARCHAR
      RIDER_IMAGE_URL VARCHAR(100) 	--RIDER_IMAGE_URL 买家头像路径
    )

CREATE TABLE TB_SHOP
    (
      --店铺表
      ID INT PRIMARY KEY
             IDENTITY(100, 1) ,					--ID INT IDENTITY(100,1), 店铺ID
      SHOP_NAME VARCHAR(20) NOT NULL ,			--SHOP_NAME VARCHAR(20) NOT NULL,店铺名
      SHOP_ADDRESS VARCHAR(100) NOT NULL ,		--SHOP_ADDRESS VARCHAR(100) NOT NULL,店铺地址
      Shop_IMAGE_URL VARCHAR(100)	    --Shop_IMAGE_URL 店铺头像路径
    )

CREATE TABLE TB_GOODS
    (
      --商品表
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--ID 商品ID
      GOODS_NAME VARCHAR(20) NOT NULL ,		--GOODS_NAME 商品名
      GOODS_PRICE FLOAT NOT NULL ,				--GOODS_PRICE 商品价格
      GOODS_TYPE VARCHAR(20) NOT NULL ,		--GOODS_TYPE 商品种类
      GOODS_DESCRIBE VARCHAR(100) ,			--GOODS_DESCRIBE 商品描述
      GOODS_REPERTORY INT NOT NULL ,			--GOODS_REPERTORY 商品库存
      GOODS_SHOP_ID INT NOT NULL ,				--GOODS_SHOP_ID 商品所属店铺ID
      GOODS_IMAGE_URL VARCHAR(100) NOT NULL,  --GOODS_IMAGE_URL 商品图片相对位置
    )

CREATE TABLE TB_CART
    (
      --购物车表
      ID INT PRIMARY KEY
             IDENTITY(20000, 1) ,	--ID 购物车ID
      CART_SHOP_ID INT NOT NULL ,				--CART_SHOP_ID 商铺ID
      CART_GOODS_ID INT NOT NULL ,				--CART_GOODS_ID 商品ID
      CART_GOODS_NUM INT NOT NULL ,			--CART_GOODS_NUM 商品数量
      CART_USER_ID INT NOT NULL,				--CART_USER_ID 用户ID
    )

CREATE TABLE TB_ORDER
    (
      --订单总览表
      ID INT PRIMARY KEY
             IDENTITY(500000, 1) ,				--ID 订单ID
      ORDER_USER_ID INT NOT NULL ,							--ORDER_USER_ID 用户ID
      ORDER_TIME DATETIME NOT NULL ,						--ORDER_TIME 订单创建时间
      ORDER_SHOP_ID INT NOT NULL ,							--ORDER_SHOP_ID 商铺ID	
      ORDER_RIDER_ID INT ,						--ORDER_RIDER_ID 骑手ID
      ORDER_NO INT NOT NULL ,								--ORDER_NO 订单号
      ORDER_ALLPRICE INT NOT NULL ,						--ORDER_ALLPRICE 订单总价
      ORDER_STATE VARCHAR(20) DEFAULT ( '未付款' )
                              NOT NULL,	--ORDER_STATE 订单状态（1.未付款 2.付款待发货 3.发货待收货 4.待评价 5.完成）
    )

SELECT  *
FROM    dbo.TB_ORDER
WHERE   ORDER_STATE = '待评价';
SELECT  *
FROM    dbo.TB_ORDER
WHERE   ORDER_STATE = '发货待收货';
SELECT  *
FROM    dbo.TB_ORDER
WHERE   ORDER_STATE = '付款待发货';
SELECT  *
FROM    dbo.TB_ORDER;

SELECT * FROM dbo.TB_ORDER,dbo.TB_BUYER,dbo.TB_SHOP WHERE dbo.TB_BUYER.ID = dbo.TB_ORDER.ORDER_USER_ID AND dbo.TB_SHOP.ID = dbo.TB_ORDER.ORDER_SHOP_ID;

CREATE TABLE TB_FLOW
    (
      --订单流水表
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,	--订单流水号
      ORDER_ID INT NOT NULL ,				--订单号
      ORDER_STATE_BRFORE VARCHAR(20) ,		--修改前
      ORDER_STATE_AFTER VARCHAR(20) ,		--修改后
      ACCOUNT VARCHAR(20) NOT NULL ,		--操作人员账号
      OPERATION_TIME DATETIME NOT NULL,	--更新时间
    )

CREATE TABLE TB_ORDER_DETAILS
    (
      --订单明细表(ORDER_DETAILS)
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,	--ID 订单明细编号
      ORDER_ID INT NOT NULL ,                  --ORDER_ID 订单号
      DETORSER_GOODS_ID INT NOT NULL ,			--DETORSER_GOODS_ID 商品ID
      DETORSER_GOODS_NUM INT NOT NULL,		--DETORSER_GOODS_NUM 商品数量
    )

CREATE TABLE TB_EVALUATE_GOODS --评论-GOODS
    (
      ID INT PRIMARY KEY
             IDENTITY(100000, 1) ,											--ID 评价ID
      EVALUATE_SHOP_ID INT NOT NULL ,													--EVALUATE_SHOP_ID 店铺ID
      GOODS_ID INT NOT NULL ,--外键 商品ID 											--GOODS_ID 商品ID
      EVALUATE_USER_ID INT ,--外键 用户ID 												--EVALUATE_USER_ID 用户ID
      EVALUATE_CONTENT VARCHAR(140) DEFAULT ( '此用户没有填写评价' ) ,					--EVALUATE_CONTENT 评价内容
      EVALUATE_STAR INT CHECK ( EVALUATE_STAR > 0
                                AND EVALUATE_STAR < 6 )
                        DEFAULT ( 5 ), 	--EVALUATE_STAR 评价星级
    )

CREATE TABLE TB_EVALUATE_RIDER
    (
      --评论-RIDER
      ID INT PRIMARY KEY
             IDENTITY(200000, 1) , 											--ID 评价ID
      RIDER_ID INT NOT NULL ,--外键 骑手ID 											--EVALUATE_RIDER_ID 骑手ID
      EVALUATE_USER_ID INT ,--外键 用户ID 												--EVALUATE_USER_ID 用户ID
      EVALUATE_STAR INT CHECK ( EVALUATE_STAR > 0
                                AND EVALUATE_STAR < 6 )
                        DEFAULT ( 5 ), 	--EVALUATE_STAR 评价星级
    )
SELECT  *
FROM    dbo.TB_RIDER;

SELECT  *
FROM    dbo.TB_EVALUATE_RIDER;

CREATE TABLE TB_BUYER_COLLECT
    (
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,	--收藏id	
      COLLECT_TYPE VARCHAR(10) NOT NULL ,	--收藏类别（店铺/商品）
      COLLECT_ID INT NOT NULL ,			--收藏目标id（店铺id/商品id）
      ACCOUNT VARCHAR(20) NOT NULL,		--收藏者账号
    )

CREATE TABLE TB_LOG
    (
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,		--日志id
      ACCOUNT VARCHAR(20) NOT NULL ,			--操作人员账号
      OPERATION_CONTENT VARCHAR(20) NOT NULL ,	--操作内容
      OPERATION_TIME DATETIME NOT NULL,		--操作时间
    )


----CREATE TABLE TB_ROLES
----(
----ID,
----ROLE_NAME,
----RELA_MENU_ID,
----ALLOW_XXX 
----)
----/*
----1 super_admin A 1
----2 super_admin B 1
----3 super_admin C 1

----4 USER A 1
----5 USER B 0
----6 USER C 0
----*/

----CREATE TABLE TB_MENU(
----ID,
----MENU_VALUE -- /HOME/Index
----)
--/*
----A 菜单
----B 菜单
----C 菜单
--*/


--插数据
--truncate table [dbo].[TB_ORDER]
--truncate table [dbo].[TB_GOODS]
--truncate table [dbo].[TB_SHOP]
--truncate table [dbo].[TB_SELLER]

INSERT  INTO [dbo].[TB_ORDER]
VALUES  ( 1001, '2017-12-28 10:04:32', 100, NULL, 600001, 998, '未付款' ),
        ( 1002, '2017-12-28 10:04:32', 100, NULL, 600002, 998, '未付款' ),
        ( 1003, '2017-12-28 10:04:32', 100, NULL, 600003, 998, '付款待发货' ),
        ( 1004, '2017-12-28 10:04:32', 100, NULL, 600004, 998, '付款待发货' ),
        ( 1005, '2017-12-28 10:04:32', 100, 1005, 600005, 998, '发货待收货' ),
        ( 1006, '2017-12-28 10:04:32', 100, 1006, 600006, 998, '发货待收货' ),
        ( 1007, '2017-12-28 10:04:32', 100, 1007, 600007, 998, '待评价' ),
        ( 1008, '2017-12-28 10:04:32', 100, 1008, 600008, 998, '待评价' ),
        ( 1009, '2017-12-28 10:04:32', 100, 1009, 600009, 998, '完成' ),
        ( 1010, '2017-12-28 10:04:32', 100, 1010, 600010, 998, '完成' ),
        ( 1001, '2017-12-28 10:04:32', 100, NULL, 600011, 998, '未付款' ),
        ( 1002, '2017-12-28 10:04:32', 100, NULL, 600012, 998, '未付款' ),
        ( 1003, '2017-12-28 10:04:32', 100, NULL, 600013, 998, '付款待发货' ),
        ( 1004, '2017-12-28 10:04:32', 100, NULL, 600014, 998, '付款待发货' ),
        ( 1005, '2017-12-28 10:04:32', 100, 1005, 600015, 998, '发货待收货' ),
        ( 1006, '2017-12-28 10:04:32', 100, 1006, 600016, 998, '发货待收货' ),
        ( 1007, '2017-12-28 10:04:32', 100, 1007, 600017, 998, '待评价' ),
        ( 1008, '2017-12-28 10:04:32', 100, 1008, 600018, 998, '待评价' ),
        ( 1009, '2017-12-28 10:04:32', 100, 1009, 600019, 998, '完成' ),
        ( 1010, '2017-12-28 10:04:32', 100, 1010, 600020, 998, '完成' ),
        ( 1001, '2017-12-28 10:04:32', 101, NULL, 600021, 998, '未付款' ),
        ( 1002, '2017-12-28 10:04:32', 101, NULL, 600022, 998, '未付款' ),
        ( 1003, '2017-12-28 10:04:32', 101, NULL, 600023, 998, '付款待发货' ),
        ( 1004, '2017-12-28 10:04:32', 101, NULL, 600024, 998, '付款待发货' ),
        ( 1005, '2017-12-28 10:04:32', 101, 1005, 600025, 998, '发货待收货' ),
        ( 1006, '2017-12-28 10:04:32', 101, 1006, 600026, 998, '发货待收货' ),
        ( 1007, '2017-12-28 10:04:32', 101, 1007, 600027, 998, '待评价' ),
        ( 1008, '2017-12-28 10:04:32', 101, 1008, 600028, 998, '待评价' ),
        ( 1009, '2017-12-28 10:04:32', 101, 1009, 600029, 998, '完成' ),
        ( 1010, '2017-12-28 10:04:32', 101, 1010, 600030, 998, '完成' ),
        ( 1001, '2017-12-28 10:04:32', 101, NULL, 600031, 998, '未付款' ),
        ( 1002, '2017-12-28 10:04:32', 101, NULL, 600032, 998, '未付款' ),
        ( 1003, '2017-12-28 10:04:32', 101, NULL, 600033, 998, '付款待发货' ),
        ( 1004, '2017-12-28 10:04:32', 101, NULL, 600034, 998, '付款待发货' ),
        ( 1005, '2017-12-28 10:04:32', 101, 1005, 600035, 998, '发货待收货' ),
        ( 1006, '2017-12-28 10:04:32', 101, 1006, 600036, 998, '发货待收货' ),
        ( 1007, '2017-12-28 10:04:32', 101, 1007, 600037, 998, '待评价' ),
        ( 1008, '2017-12-28 10:04:32', 101, 1008, 600038, 998, '待评价' ),
        ( 1009, '2017-12-28 10:04:32', 101, 1009, 600039, 998, '完成' ),
        ( 1010, '2017-12-28 10:04:32', 101, 1010, 600040, 998, '完成' )

INSERT  INTO [dbo].[TB_GOODS]
VALUES  ( '苹果', 3, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=T1kngcFfxeXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '蓝莓', 15, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=TB1LBu9JVXXXXXZXFXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '猕猴桃', 5, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=TB1roYQHXXXXXXhaXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '车厘子', 16, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=TB2DVzejFXXXXXyXpXXXXXXXXXX_!!67901011.jpg&_dc=new Data()' ),
        ( '柠檬', 19, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=TB2kEXRiX9gSKJjSspbXXbeNXXa_!!1990516179.jpg&_dc=new Data()' ),
        ( '芒果', 16, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=TB2w2FBlBDH8KJjSszcXXbDTFXa_!!2087715324.jpg&_dc=new Data()' ),
        ( '橙子', 5, '水果', '阿明水果店的苹果', 10000, 100, '/Seller/GetImage?imgName=TB10xMnJpXXXXbXXVXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),

        ( '腰果', 59, '零食', '良品铺子的腰果', 10000, 101, '/Seller/GetImage?imgName=TB1fScXLFXXXXXoaXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '夏威夷果', 49, '零食', '良品铺子的夏威夷果', 10000, 101, '/Seller/GetImage?imgName=TB1MX4qHpXXXXcoXpXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '板栗', 19, '零食', '良品铺子的板栗', 10000, 101, '/Seller/GetImage?imgName=TB16LqTHFXXXXctXXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '巴旦木', 45, '零食', '良品铺子的巴旦木', 10000, 101, '/Seller/GetImage?imgName=TB13LnuLXXXXXbqXVXXAHI79FXX_045548.jpg&_dc=new Data()' ),
        ( '松子', 49, '零食', '良品铺子的松子', 10000, 101, '/Seller/GetImage?imgName=TB2IuvnXSJjpuFjy0FdXXXmoFXa_!!572059930.jpg&_dc=new Data()' ),
        ( '菠萝片', 19, '零食', '良品铺子的菠萝片', 10000, 101, '/Seller/GetImage?imgName=TB2cQ4sj3fH8KJjy1zcXXcTzpXa_!!572059930.jpg&_dc=new Data()' ),
        ( '鱼豆腐', 21, '零食', '良品铺子的鱼豆腐', 10000, 101, '/Seller/GetImage?imgName=TB2A7EUcxHI8KJjy1zbXXaxdpXa_!!1607050979.jpg&_dc=new Data()' ),
        ( '沙琪玛', 18, '零食', '良品铺子的沙琪玛', 10000, 101, '/Seller/GetImage?imgName=TB1P4whIpXXXXaaXFXX5F8A.FXX_105358.jpg&_dc=new Data()' ),
        ( '葵瓜子', 15, '零食', '良品铺子的葵瓜子', 10000, 101, '/Seller/GetImage?imgName=TB2.v88cHJmpuFjSZFBXXXaZXXa_!!277227205.jpg&_dc=new Data()' ),
        ( '柠檬片', 16, '零食', '良品铺子的柠檬片', 10000, 101, '/Seller/GetImage?imgName=TB2IzjPymFmpuFjSZFrXXayOXXa_!!277227205.jpg&_dc=new Data()' ),
        ( '猪肉脯', 20, '零食', '良品铺子的猪肉脯', 10000, 101, '/Seller/GetImage?imgName=TB2WNPVcDnI8KJjy0FfXXcdoVXa_!!277227205.jpg&_dc=new Data()' ),
        ( '鸡蛋干', 15, '零食', '良品铺子的鸡蛋干', 10000, 101, '/Seller/GetImage?imgName=TB2A7EUcxHI8KJjy1zbXXaxdpXa_!!1607050979.jpg&_dc=new Data()' ),
        ( '绿豆糕', 23, '零食', '良品铺子的绿豆糕', 10000, 101, '/Seller/GetImage?imgName=TB2iz.BmhTI8KJjSspiXXbM4FXa_!!277227205.jpg&_dc=new Data()' ),
        ( '香蕉片', 16, '零食', '良品铺子的香蕉片', 10000, 101, '/Seller/GetImage?imgName=TB1kAYGIVXXXXbHXVXXjAOi8pXX_022852.jpg&_dc=new Data()' ),
        ( '碧根果', 59, '零食', '良品铺子的碧根果', 10000, 101, '/Seller/GetImage?imgName=TB2hHmBb7.HL1JjSZFuXXX8dXXa_!!572059930.jpg&_dc=new Data()' ),

		( '鸭脖', 16, '零食', '三只松鼠的鸭脖', 10000, 102, '/Seller/GetImage?imgName=TB1Op8_igLD8KJjSszeXXaGRpXa_!!0-item_pic.jpg&_dc=new Data()' ),
		( '松子', 49, '零食', '三只松鼠的松子', 10000, 102, '/Seller/GetImage?imgName=TB1sOJ7JFXXXXXVaXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
		( '凤爪', 29, '零食', '三只松鼠的凤爪', 10000, 102, '/Seller/GetImage?imgName=TB2L.n1gXXXXXXLXpXXXXXXXXXX_!!2266033239.jpg&_dc=new Data()' ),
		( '黑皮花生', 20, '零食', '三只松鼠的黑皮花生', 10000, 102, '/Seller/GetImage?imgName=TB2TOrhcoWO.eBjSZPcXXbopVXa_!!756810899.jpg&_dc=new Data()' ),
		( '葡萄干', 21, '零食', '三只松鼠的葡萄干', 10000, 102, '/Seller/GetImage?imgName=TB2GhUmlFXXXXakXpXXXXXXXXXX_!!2324834877.jpg&_dc=new Data()' ),
		( '腰果', 55, '零食', '三只松鼠的腰果', 10000, 102, '/Seller/GetImage?imgName=TB1SrynHXXXXXc.aXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
		( '鸭肫', 29, '零食', '三只松鼠的鸭肫', 10000, 102, '/Seller/GetImage?imgName=TB2uQ6flFXXXXb7XpXXXXXXXXXX_!!2324834877.jpg&_dc=new Data()' ),
		( '榴莲干', 30, '零食', '三只松鼠的榴莲干', 10000, 102, '/Seller/GetImage?imgName=TB1d57IIXXXXXaKXXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
		( '柠檬干', 27, '零食', '三只松鼠的柠檬干', 10000, 102, '/Seller/GetImage?imgName=TB2HfMYeFXXXXXiXXXXXXXXXXXX_!!1956010090.png&_dc=new Data()' ),
		( '麻薯', 37, '零食', '三只松鼠的麻薯', 10000, 102, '/Seller/GetImage?imgName=TB23lwPipXXXXagXpXXXXXXXXXX_!!2266033239.jpg&_dc=new Data()' ),
		( '坚果大礼包', 279, '零食', '三只松鼠的坚果大礼包', 10000, 102, '/Seller/GetImage?imgName=TB2X5udbbPx2eJjSZFBXXbmZVXa_!!756810899.jpg&_dc=new Data()' )

INSERT  INTO [dbo].[TB_SELLER]
VALUES  ( 'aming', '123', '小明', 100, '安徽芜湖弋江区17号', '15755321111', 1, '' ),
        ( 'liangpin', '123', '张三', 101, '安徽芜湖弋江区18号', '15755322222', 1, '' ),
		('songshu','123','李四',102,'安徽芜湖弋江区19号','15755323333',1,'')

INSERT  INTO [dbo].[TB_SHOP]
VALUES  ( '阿明水果店', '安徽芜湖弋江区17号', NULL ),
        ( '良品铺子', '安徽芜湖弋江区18号', NULL ),
		( '三只松鼠', '安徽芜湖弋江区19号', NULL )

INSERT  INTO dbo.TB_ORDER_DETAILS
VALUES  ( 1, 10000, 2 ),
        ( 1, 10001, 3 ),
        ( 1, 10002, 1 )

INSERT  INTO [dbo].[TB_BUYER]
VALUES  ( 'wangwu', '123', '王五', '芜湖安信工', '12345678910', 1, 'sss' ),
        ( 'zhaoliu', '123', '赵六', '芜湖安信工', '12345678999', 1, 'sss' )


