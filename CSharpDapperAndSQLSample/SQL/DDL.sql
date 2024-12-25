CREATE TABLE arima_kinen
(
    umaban INTEGER PRIMARY KEY, -- 自動採番
	wakuban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo REAL NOT NULL, -- REAL型で小数点以下の桁数を指定
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL
);

CREATE TABLE takarazuka_kinen
(
    umaban INTEGER PRIMARY KEY, -- 自動採番
	wakuban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo REAL NOT NULL, -- REAL型で小数点以下の桁数を指定
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL
);

CREATE TABLE tokyo_yushun
(
	kaisu INTEGER NOT NULL,  
	wakuban INTEGER NOT NULL,
	umaban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo REAL NOT NULL, -- REAL型で小数点以下の桁数を指定
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL,
	UNIQUE(kaisu, wakuban, umaban) -- UNIQUE制約で回数、枠番、馬番の組み合わせが一意になるようにする
);

CREATE TABLE dubai_sheema_classic
(
	kaisu INTEGER NOT NULL,
	wakuban INTEGER NOT NULL,
    umaban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo REAL NOT NULL, -- REAL型で小数点以下の桁数を指定
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL,
	UNIQUE(kaisu, wakuban, umaban) -- UNIQUE制約で回数、枠番、馬番の組み合わせが一意になるようにする
);

CREATE TABLE sample
(
	user_id INTEGER PRIMARY KEY, -- 自動採番
	user_sub_id INTEGER NOT NULL,
	user_name TEXT NOT NULL,
	user_sub_name TEXT NOT NULL,
);