
DROP TABLE MoneyDotNetDB.GuDing_JiaoYi;
DROP TABLE MoneyDotNetDB.TouZi_JiaoYi;
DROP TABLE MoneyDotNetDB.RiChang_JiaoYi;
DROP TABLE MoneyDotNetDB.JiaoYi_FS;
DROP TABLE MoneyDotNetDB.JiaoYi_FenLei;
DROP TABLE MoneyDotNetDB.ShiJian_ZhouQi;

CREATE TABLE MoneyDotNetDB.ShiJian_ZhouQi (
       ID SERIAL8 NOT NULL
     , ZhouQi_QuJian INT8
     , ZhouQi_DanWei CHAR(1)
     , PRIMARY KEY (ID)
);

CREATE TABLE MoneyDotNetDB.JiaoYi_FenLei (
       ID SERIAL8 NOT NULL
     , MingCheng VARCHAR(50)
     , PRIMARY KEY (ID)
);

CREATE TABLE MoneyDotNetDB.JiaoYi_FS (
       ID SERIAL8 NOT NULL
     , Name VARCHAR(50)
     , PRIMARY KEY (ID)
);

CREATE TABLE MoneyDotNetDB.RiChang_JiaoYi (
       ID SERIAL8 NOT NULL
     , JiaoYi_FangXiang CHAR(1)
     , MingCheng VARCHAR(50)
     , JiaoYi_FS_ID INT8
     , FenLei_ID INT8
     , FaSheng_Time TIMESTAMP
     , Jin_E DECIMAL(11,2)
     , MiaoShu VARCHAR(255)
     , PRIMARY KEY (ID)
     , CONSTRAINT FK_RiChang_JiaoYi_2 FOREIGN KEY (FenLei_ID)
                  REFERENCES MoneyDotNetDB.JiaoYi_FenLei (ID)
     , CONSTRAINT FK_RiChang_JiaoYi_3 FOREIGN KEY (JiaoYi_FS_ID)
                  REFERENCES MoneyDotNetDB.JiaoYi_FS (ID)
);

CREATE TABLE MoneyDotNetDB.TouZi_JiaoYi (
       ID SERIAL NOT NULL
     , MingCheng VARCHAR(50)
     , DaiMa VARCHAR(10)
     , JiaoYi_Time TIMESTAMP
     , Jin_E DECIMAL(11,2)
     , FenLei_ID INT8
     , PRIMARY KEY (ID)
     , CONSTRAINT FK_TouZi_JiaoYi_1 FOREIGN KEY (FenLei_ID)
                  REFERENCES MoneyDotNetDB.JiaoYi_FenLei (ID)
);

CREATE TABLE MoneyDotNetDB.GuDing_JiaoYi (
       ID SERIAL8 NOT NULL
     , MingCheng VARCHAR(50)
     , JiaoYi_FangXiang CHAR(1)
     , JiaoYi_ZhouQi_ID INT8
     , JiaoYi_FS_ID INT8
     , Start_Time TIMESTAMP
     , Stop_Time TIMESTAMP
     , Jin_E DECIMAL(11,2)
     , FenLei_ID INT8
     , MiaoShu VARCHAR(255)
     , PRIMARY KEY (ID)
     , CONSTRAINT FK_GuDing_JiaoYi_1 FOREIGN KEY (JiaoYi_ZhouQi_ID)
                  REFERENCES MoneyDotNetDB.ShiJian_ZhouQi (ID)
     , CONSTRAINT FK_GuDing_JiaoYi_2 FOREIGN KEY (FenLei_ID)
                  REFERENCES MoneyDotNetDB.JiaoYi_FenLei (ID)
     , CONSTRAINT FK_GuDing_JiaoYi_3 FOREIGN KEY (JiaoYi_FS_ID)
                  REFERENCES MoneyDotNetDB.JiaoYi_FS (ID)
);

