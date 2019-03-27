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
      --����Ա��
      ADMIN_ID VARCHAR(20) PRIMARY KEY
                           NOT NULL ,	--ID �˺�
      ADMIN_PWD VARCHAR(20) NOT NULL,				--PWD ����
    )

CREATE TABLE TB_BUYER
    (
      --������Ϣ��-��ұ�
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--BUYER_ID ID INT
      ACCOUNT VARCHAR(20) NOT NULL ,			--ACCOUNT �˺� VARCAHR
      PWD VARCHAR(20) NOT NULL ,				--PWD ���� VARCHAR
      BUYER_NAME VARCHAR(20) ,		--BUYER_NAME �ǳ� VARCHAR
      BUYER_ADDRESS VARCHAR(100) ,	--BUYER_ADDRESS �ջ���ַ VARCHAR
      BUYER_TEL VARCHAR(11) ,			--BUYER_TEL ��ϵ�绰 VARCHAR 
      PERMISSIONS BIT DEFAULT ( 1 ) ,			--PERMISSIONS Ȩ�� VARCHAR
      BUYER_IMAGE_URL VARCHAR(100)	--BUYER_IMAGE_URL ���ͷ��·��
    )

CREATE TABLE TB_SELLER
    (
      --������Ϣ��-���ұ�
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--ID ID INT
      ACCOUNT VARCHAR(20) NOT NULL ,			--ACCOUNT �˺� VARCAHR
      PWD VARCHAR(20) NOT NULL ,				--PWD ���� VARCHAR
      SELLER_NAME VARCHAR(20) ,		--SELLER_NAME �ǳ� VARCHAR
      SHOP_ID INT ,					--SHOP_ID ���̺� VARCHAR
      BUYER_ADDRESS VARCHAR(100) ,	--BUYER_ADDRESS �ջ���ַ VARCHAR
      BUYER_TEL VARCHAR(11) ,			--BUYER_TEL ��ϵ�绰 VARCHAR (����)
      PERMISSIONS BIT DEFAULT ( 1 ) ,				--PERMISSIONS Ȩ�� VARCHAR
      SELLER_IMAGE_URL VARCHAR(100) 	--SELLER_IMAGE_URL ����ͷ��·��
    )

CREATE TABLE TB_RIDER
    (
      --������Ϣ-���ֱ�
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--ID ID INT
      ACCOUNT VARCHAR(20) NOT NULL ,			--ACCOUNT �˺� VARCAHR
      PWD VARCHAR(20) NOT NULL ,				--PWD ���� VARCHAR
      RIDER_NAME VARCHAR(20) , 				--RIDER_NAME VARCHAR �ǳ� 
      BUYER_ADDRESS VARCHAR(100) ,				--BUYER_ADDRESS VARCHAR ��ַ
      BUYER_TEL VARCHAR(11) ,					--BUYER_TEL VARCHAR�����ã��绰
      PERMISSIONS BIT DEFAULT ( 1 ) ,				--PERMISSIONS Ȩ�� VARCHAR
      RIDER_IMAGE_URL VARCHAR(100) 	--RIDER_IMAGE_URL ���ͷ��·��
    )

CREATE TABLE TB_SHOP
    (
      --���̱�
      ID INT PRIMARY KEY
             IDENTITY(100, 1) ,					--ID INT IDENTITY(100,1), ����ID
      SHOP_NAME VARCHAR(20) NOT NULL ,			--SHOP_NAME VARCHAR(20) NOT NULL,������
      SHOP_ADDRESS VARCHAR(100) NOT NULL ,		--SHOP_ADDRESS VARCHAR(100) NOT NULL,���̵�ַ
      Shop_IMAGE_URL VARCHAR(100)	    --Shop_IMAGE_URL ����ͷ��·��
    )

CREATE TABLE TB_GOODS
    (
      --��Ʒ��
      ID INT PRIMARY KEY
             IDENTITY(10000, 1) ,	--ID ��ƷID
      GOODS_NAME VARCHAR(20) NOT NULL ,		--GOODS_NAME ��Ʒ��
      GOODS_PRICE FLOAT NOT NULL ,				--GOODS_PRICE ��Ʒ�۸�
      GOODS_TYPE VARCHAR(20) NOT NULL ,		--GOODS_TYPE ��Ʒ����
      GOODS_DESCRIBE VARCHAR(100) ,			--GOODS_DESCRIBE ��Ʒ����
      GOODS_REPERTORY INT NOT NULL ,			--GOODS_REPERTORY ��Ʒ���
      GOODS_SHOP_ID INT NOT NULL ,				--GOODS_SHOP_ID ��Ʒ��������ID
      GOODS_IMAGE_URL VARCHAR(100) NOT NULL,  --GOODS_IMAGE_URL ��ƷͼƬ���λ��
    )

CREATE TABLE TB_CART
    (
      --���ﳵ��
      ID INT PRIMARY KEY
             IDENTITY(20000, 1) ,	--ID ���ﳵID
      CART_SHOP_ID INT NOT NULL ,				--CART_SHOP_ID ����ID
      CART_GOODS_ID INT NOT NULL ,				--CART_GOODS_ID ��ƷID
      CART_GOODS_NUM INT NOT NULL ,			--CART_GOODS_NUM ��Ʒ����
      CART_USER_ID INT NOT NULL,				--CART_USER_ID �û�ID
    )

CREATE TABLE TB_ORDER
    (
      --����������
      ID INT PRIMARY KEY
             IDENTITY(500000, 1) ,				--ID ����ID
      ORDER_USER_ID INT NOT NULL ,							--ORDER_USER_ID �û�ID
      ORDER_TIME DATETIME NOT NULL ,						--ORDER_TIME ��������ʱ��
      ORDER_SHOP_ID INT NOT NULL ,							--ORDER_SHOP_ID ����ID	
      ORDER_RIDER_ID INT ,						--ORDER_RIDER_ID ����ID
      ORDER_NO INT NOT NULL ,								--ORDER_NO ������
      ORDER_ALLPRICE INT NOT NULL ,						--ORDER_ALLPRICE �����ܼ�
      ORDER_STATE VARCHAR(20) DEFAULT ( 'δ����' )
                              NOT NULL,	--ORDER_STATE ����״̬��1.δ���� 2.��������� 3.�������ջ� 4.������ 5.��ɣ�
    )

SELECT  *
FROM    dbo.TB_ORDER
WHERE   ORDER_STATE = '������';
SELECT  *
FROM    dbo.TB_ORDER
WHERE   ORDER_STATE = '�������ջ�';
SELECT  *
FROM    dbo.TB_ORDER
WHERE   ORDER_STATE = '���������';
SELECT  *
FROM    dbo.TB_ORDER;

SELECT * FROM dbo.TB_ORDER,dbo.TB_BUYER,dbo.TB_SHOP WHERE dbo.TB_BUYER.ID = dbo.TB_ORDER.ORDER_USER_ID AND dbo.TB_SHOP.ID = dbo.TB_ORDER.ORDER_SHOP_ID;

CREATE TABLE TB_FLOW
    (
      --������ˮ��
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,	--������ˮ��
      ORDER_ID INT NOT NULL ,				--������
      ORDER_STATE_BRFORE VARCHAR(20) ,		--�޸�ǰ
      ORDER_STATE_AFTER VARCHAR(20) ,		--�޸ĺ�
      ACCOUNT VARCHAR(20) NOT NULL ,		--������Ա�˺�
      OPERATION_TIME DATETIME NOT NULL,	--����ʱ��
    )

CREATE TABLE TB_ORDER_DETAILS
    (
      --������ϸ��(ORDER_DETAILS)
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,	--ID ������ϸ���
      ORDER_ID INT NOT NULL ,                  --ORDER_ID ������
      DETORSER_GOODS_ID INT NOT NULL ,			--DETORSER_GOODS_ID ��ƷID
      DETORSER_GOODS_NUM INT NOT NULL,		--DETORSER_GOODS_NUM ��Ʒ����
    )

CREATE TABLE TB_EVALUATE_GOODS --����-GOODS
    (
      ID INT PRIMARY KEY
             IDENTITY(100000, 1) ,											--ID ����ID
      EVALUATE_SHOP_ID INT NOT NULL ,													--EVALUATE_SHOP_ID ����ID
      GOODS_ID INT NOT NULL ,--��� ��ƷID 											--GOODS_ID ��ƷID
      EVALUATE_USER_ID INT ,--��� �û�ID 												--EVALUATE_USER_ID �û�ID
      EVALUATE_CONTENT VARCHAR(140) DEFAULT ( '���û�û����д����' ) ,					--EVALUATE_CONTENT ��������
      EVALUATE_STAR INT CHECK ( EVALUATE_STAR > 0
                                AND EVALUATE_STAR < 6 )
                        DEFAULT ( 5 ), 	--EVALUATE_STAR �����Ǽ�
    )

CREATE TABLE TB_EVALUATE_RIDER
    (
      --����-RIDER
      ID INT PRIMARY KEY
             IDENTITY(200000, 1) , 											--ID ����ID
      RIDER_ID INT NOT NULL ,--��� ����ID 											--EVALUATE_RIDER_ID ����ID
      EVALUATE_USER_ID INT ,--��� �û�ID 												--EVALUATE_USER_ID �û�ID
      EVALUATE_STAR INT CHECK ( EVALUATE_STAR > 0
                                AND EVALUATE_STAR < 6 )
                        DEFAULT ( 5 ), 	--EVALUATE_STAR �����Ǽ�
    )
SELECT  *
FROM    dbo.TB_RIDER;

SELECT  *
FROM    dbo.TB_EVALUATE_RIDER;

CREATE TABLE TB_BUYER_COLLECT
    (
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,	--�ղ�id	
      COLLECT_TYPE VARCHAR(10) NOT NULL ,	--�ղ���𣨵���/��Ʒ��
      COLLECT_ID INT NOT NULL ,			--�ղ�Ŀ��id������id/��Ʒid��
      ACCOUNT VARCHAR(20) NOT NULL,		--�ղ����˺�
    )

CREATE TABLE TB_LOG
    (
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,		--��־id
      ACCOUNT VARCHAR(20) NOT NULL ,			--������Ա�˺�
      OPERATION_CONTENT VARCHAR(20) NOT NULL ,	--��������
      OPERATION_TIME DATETIME NOT NULL,		--����ʱ��
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
----A �˵�
----B �˵�
----C �˵�
--*/


--������
--truncate table [dbo].[TB_ORDER]
--truncate table [dbo].[TB_GOODS]
--truncate table [dbo].[TB_SHOP]
--truncate table [dbo].[TB_SELLER]

INSERT  INTO [dbo].[TB_ORDER]
VALUES  ( 1001, '2017-12-28 10:04:32', 100, NULL, 600001, 998, 'δ����' ),
        ( 1002, '2017-12-28 10:04:32', 100, NULL, 600002, 998, 'δ����' ),
        ( 1003, '2017-12-28 10:04:32', 100, NULL, 600003, 998, '���������' ),
        ( 1004, '2017-12-28 10:04:32', 100, NULL, 600004, 998, '���������' ),
        ( 1005, '2017-12-28 10:04:32', 100, 1005, 600005, 998, '�������ջ�' ),
        ( 1006, '2017-12-28 10:04:32', 100, 1006, 600006, 998, '�������ջ�' ),
        ( 1007, '2017-12-28 10:04:32', 100, 1007, 600007, 998, '������' ),
        ( 1008, '2017-12-28 10:04:32', 100, 1008, 600008, 998, '������' ),
        ( 1009, '2017-12-28 10:04:32', 100, 1009, 600009, 998, '���' ),
        ( 1010, '2017-12-28 10:04:32', 100, 1010, 600010, 998, '���' ),
        ( 1001, '2017-12-28 10:04:32', 100, NULL, 600011, 998, 'δ����' ),
        ( 1002, '2017-12-28 10:04:32', 100, NULL, 600012, 998, 'δ����' ),
        ( 1003, '2017-12-28 10:04:32', 100, NULL, 600013, 998, '���������' ),
        ( 1004, '2017-12-28 10:04:32', 100, NULL, 600014, 998, '���������' ),
        ( 1005, '2017-12-28 10:04:32', 100, 1005, 600015, 998, '�������ջ�' ),
        ( 1006, '2017-12-28 10:04:32', 100, 1006, 600016, 998, '�������ջ�' ),
        ( 1007, '2017-12-28 10:04:32', 100, 1007, 600017, 998, '������' ),
        ( 1008, '2017-12-28 10:04:32', 100, 1008, 600018, 998, '������' ),
        ( 1009, '2017-12-28 10:04:32', 100, 1009, 600019, 998, '���' ),
        ( 1010, '2017-12-28 10:04:32', 100, 1010, 600020, 998, '���' ),
        ( 1001, '2017-12-28 10:04:32', 101, NULL, 600021, 998, 'δ����' ),
        ( 1002, '2017-12-28 10:04:32', 101, NULL, 600022, 998, 'δ����' ),
        ( 1003, '2017-12-28 10:04:32', 101, NULL, 600023, 998, '���������' ),
        ( 1004, '2017-12-28 10:04:32', 101, NULL, 600024, 998, '���������' ),
        ( 1005, '2017-12-28 10:04:32', 101, 1005, 600025, 998, '�������ջ�' ),
        ( 1006, '2017-12-28 10:04:32', 101, 1006, 600026, 998, '�������ջ�' ),
        ( 1007, '2017-12-28 10:04:32', 101, 1007, 600027, 998, '������' ),
        ( 1008, '2017-12-28 10:04:32', 101, 1008, 600028, 998, '������' ),
        ( 1009, '2017-12-28 10:04:32', 101, 1009, 600029, 998, '���' ),
        ( 1010, '2017-12-28 10:04:32', 101, 1010, 600030, 998, '���' ),
        ( 1001, '2017-12-28 10:04:32', 101, NULL, 600031, 998, 'δ����' ),
        ( 1002, '2017-12-28 10:04:32', 101, NULL, 600032, 998, 'δ����' ),
        ( 1003, '2017-12-28 10:04:32', 101, NULL, 600033, 998, '���������' ),
        ( 1004, '2017-12-28 10:04:32', 101, NULL, 600034, 998, '���������' ),
        ( 1005, '2017-12-28 10:04:32', 101, 1005, 600035, 998, '�������ջ�' ),
        ( 1006, '2017-12-28 10:04:32', 101, 1006, 600036, 998, '�������ջ�' ),
        ( 1007, '2017-12-28 10:04:32', 101, 1007, 600037, 998, '������' ),
        ( 1008, '2017-12-28 10:04:32', 101, 1008, 600038, 998, '������' ),
        ( 1009, '2017-12-28 10:04:32', 101, 1009, 600039, 998, '���' ),
        ( 1010, '2017-12-28 10:04:32', 101, 1010, 600040, 998, '���' )

INSERT  INTO [dbo].[TB_GOODS]
VALUES  ( 'ƻ��', 3, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=T1kngcFfxeXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '��ݮ', 15, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=TB1LBu9JVXXXXXZXFXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '⨺���', 5, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=TB1roYQHXXXXXXhaXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '������', 16, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=TB2DVzejFXXXXXyXpXXXXXXXXXX_!!67901011.jpg&_dc=new Data()' ),
        ( '����', 19, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=TB2kEXRiX9gSKJjSspbXXbeNXXa_!!1990516179.jpg&_dc=new Data()' ),
        ( 'â��', 16, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=TB2w2FBlBDH8KJjSszcXXbDTFXa_!!2087715324.jpg&_dc=new Data()' ),
        ( '����', 5, 'ˮ��', '����ˮ�����ƻ��', 10000, 100, '/Seller/GetImage?imgName=TB10xMnJpXXXXbXXVXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),

        ( '����', 59, '��ʳ', '��Ʒ���ӵ�����', 10000, 101, '/Seller/GetImage?imgName=TB1fScXLFXXXXXoaXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '�����Ĺ�', 49, '��ʳ', '��Ʒ���ӵ������Ĺ�', 10000, 101, '/Seller/GetImage?imgName=TB1MX4qHpXXXXcoXpXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '����', 19, '��ʳ', '��Ʒ���ӵİ���', 10000, 101, '/Seller/GetImage?imgName=TB16LqTHFXXXXctXXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
        ( '�͵�ľ', 45, '��ʳ', '��Ʒ���ӵİ͵�ľ', 10000, 101, '/Seller/GetImage?imgName=TB13LnuLXXXXXbqXVXXAHI79FXX_045548.jpg&_dc=new Data()' ),
        ( '����', 49, '��ʳ', '��Ʒ���ӵ�����', 10000, 101, '/Seller/GetImage?imgName=TB2IuvnXSJjpuFjy0FdXXXmoFXa_!!572059930.jpg&_dc=new Data()' ),
        ( '����Ƭ', 19, '��ʳ', '��Ʒ���ӵĲ���Ƭ', 10000, 101, '/Seller/GetImage?imgName=TB2cQ4sj3fH8KJjy1zcXXcTzpXa_!!572059930.jpg&_dc=new Data()' ),
        ( '�㶹��', 21, '��ʳ', '��Ʒ���ӵ��㶹��', 10000, 101, '/Seller/GetImage?imgName=TB2A7EUcxHI8KJjy1zbXXaxdpXa_!!1607050979.jpg&_dc=new Data()' ),
        ( 'ɳ����', 18, '��ʳ', '��Ʒ���ӵ�ɳ����', 10000, 101, '/Seller/GetImage?imgName=TB1P4whIpXXXXaaXFXX5F8A.FXX_105358.jpg&_dc=new Data()' ),
        ( '������', 15, '��ʳ', '��Ʒ���ӵĿ�����', 10000, 101, '/Seller/GetImage?imgName=TB2.v88cHJmpuFjSZFBXXXaZXXa_!!277227205.jpg&_dc=new Data()' ),
        ( '����Ƭ', 16, '��ʳ', '��Ʒ���ӵ�����Ƭ', 10000, 101, '/Seller/GetImage?imgName=TB2IzjPymFmpuFjSZFrXXayOXXa_!!277227205.jpg&_dc=new Data()' ),
        ( '���⸬', 20, '��ʳ', '��Ʒ���ӵ����⸬', 10000, 101, '/Seller/GetImage?imgName=TB2WNPVcDnI8KJjy0FfXXcdoVXa_!!277227205.jpg&_dc=new Data()' ),
        ( '������', 15, '��ʳ', '��Ʒ���ӵļ�����', 10000, 101, '/Seller/GetImage?imgName=TB2A7EUcxHI8KJjy1zbXXaxdpXa_!!1607050979.jpg&_dc=new Data()' ),
        ( '�̶���', 23, '��ʳ', '��Ʒ���ӵ��̶���', 10000, 101, '/Seller/GetImage?imgName=TB2iz.BmhTI8KJjSspiXXbM4FXa_!!277227205.jpg&_dc=new Data()' ),
        ( '�㽶Ƭ', 16, '��ʳ', '��Ʒ���ӵ��㽶Ƭ', 10000, 101, '/Seller/GetImage?imgName=TB1kAYGIVXXXXbHXVXXjAOi8pXX_022852.jpg&_dc=new Data()' ),
        ( '�̸���', 59, '��ʳ', '��Ʒ���ӵı̸���', 10000, 101, '/Seller/GetImage?imgName=TB2hHmBb7.HL1JjSZFuXXX8dXXa_!!572059930.jpg&_dc=new Data()' ),

		( 'Ѽ��', 16, '��ʳ', '��ֻ�����Ѽ��', 10000, 102, '/Seller/GetImage?imgName=TB1Op8_igLD8KJjSszeXXaGRpXa_!!0-item_pic.jpg&_dc=new Data()' ),
		( '����', 49, '��ʳ', '��ֻ���������', 10000, 102, '/Seller/GetImage?imgName=TB1sOJ7JFXXXXXVaXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
		( '��צ', 29, '��ʳ', '��ֻ����ķ�צ', 10000, 102, '/Seller/GetImage?imgName=TB2L.n1gXXXXXXLXpXXXXXXXXXX_!!2266033239.jpg&_dc=new Data()' ),
		( '��Ƥ����', 20, '��ʳ', '��ֻ����ĺ�Ƥ����', 10000, 102, '/Seller/GetImage?imgName=TB2TOrhcoWO.eBjSZPcXXbopVXa_!!756810899.jpg&_dc=new Data()' ),
		( '���Ѹ�', 21, '��ʳ', '��ֻ��������Ѹ�', 10000, 102, '/Seller/GetImage?imgName=TB2GhUmlFXXXXakXpXXXXXXXXXX_!!2324834877.jpg&_dc=new Data()' ),
		( '����', 55, '��ʳ', '��ֻ���������', 10000, 102, '/Seller/GetImage?imgName=TB1SrynHXXXXXc.aXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
		( 'Ѽ��', 29, '��ʳ', '��ֻ�����Ѽ��', 10000, 102, '/Seller/GetImage?imgName=TB2uQ6flFXXXXb7XpXXXXXXXXXX_!!2324834877.jpg&_dc=new Data()' ),
		( '������', 30, '��ʳ', '��ֻ�����������', 10000, 102, '/Seller/GetImage?imgName=TB1d57IIXXXXXaKXXXXXXXXXXXX_!!0-item_pic.jpg&_dc=new Data()' ),
		( '���ʸ�', 27, '��ʳ', '��ֻ��������ʸ�', 10000, 102, '/Seller/GetImage?imgName=TB2HfMYeFXXXXXiXXXXXXXXXXXX_!!1956010090.png&_dc=new Data()' ),
		( '����', 37, '��ʳ', '��ֻ���������', 10000, 102, '/Seller/GetImage?imgName=TB23lwPipXXXXagXpXXXXXXXXXX_!!2266033239.jpg&_dc=new Data()' ),
		( '��������', 279, '��ʳ', '��ֻ����ļ�������', 10000, 102, '/Seller/GetImage?imgName=TB2X5udbbPx2eJjSZFBXXbmZVXa_!!756810899.jpg&_dc=new Data()' )

INSERT  INTO [dbo].[TB_SELLER]
VALUES  ( 'aming', '123', 'С��', 100, '�����ߺ�߮����17��', '15755321111', 1, '' ),
        ( 'liangpin', '123', '����', 101, '�����ߺ�߮����18��', '15755322222', 1, '' ),
		('songshu','123','����',102,'�����ߺ�߮����19��','15755323333',1,'')

INSERT  INTO [dbo].[TB_SHOP]
VALUES  ( '����ˮ����', '�����ߺ�߮����17��', NULL ),
        ( '��Ʒ����', '�����ߺ�߮����18��', NULL ),
		( '��ֻ����', '�����ߺ�߮����19��', NULL )

INSERT  INTO dbo.TB_ORDER_DETAILS
VALUES  ( 1, 10000, 2 ),
        ( 1, 10001, 3 ),
        ( 1, 10002, 1 )

INSERT  INTO [dbo].[TB_BUYER]
VALUES  ( 'wangwu', '123', '����', '�ߺ����Ź�', '12345678910', 1, 'sss' ),
        ( 'zhaoliu', '123', '����', '�ߺ����Ź�', '12345678999', 1, 'sss' )


