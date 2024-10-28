CREATE TABLE arima_kinen
(
    umaban INTEGER PRIMARY KEY, -- 自動採番
	wakuban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo INTEGER NOT NULL,
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
	kinryo INTEGER NOT NULL,
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL
);

CREATE TABLE tokyo_yushun
(
	kaisu INTEGER,
    umaban INTEGER PRIMARY KEY, -- 自動採番
	wakuban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo INTEGER NOT NULL,
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL,
	UNIQUE(kaisu, umaban) -- UNIQUE制約で回数と馬番の組み合わせが一意になるようにする
);