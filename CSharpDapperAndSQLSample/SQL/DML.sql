INSERT INTO arima_kinen
(
	wakuban,
	bamei,
	seibetu,
	barei,
	kinryo,
	kisyu,
	kyusya,
	createdate,
	updatedate
)
VALUES
(1, 'アカイイト', '牝', '5', '55.0', '幸', '中竹', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(1, 'イズジョーノキセキ', '牝', '5', '55.0', '岩田康', '石坂', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(2, 'ボルドグフーシュ', '牡', '3', '55.0', '福永', '宮本', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(2, 'アリストテレス', '牡', '5', '57.0', '武豊', '音無', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(3, 'ジェラルディーナ', '牝', '4', '55.0', 'Ｃデムーロ', '斉藤崇', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(3, 'ヴェラアズール', '牡', '5', '57.0', '松山', '渡辺', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(4, 'エフフォーリア', '牡', '4', '57.0', '横山武', '鹿戸', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(4, 'ウインマイティー', '牝', '5', '55.0', '和田竜', '五十嵐', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(5, 'イクイノックス', '牡', '3', '55.0', 'ルメール', '木村', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(5, 'ジャスティンパレス', '牡', '3', '55.0', 'マーカンド', '杉山晴', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(6, 'ラストドラフト', '牡', '6', '57.0', '三浦', '戸田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(6, 'ポタジェ', '牡', '5', '57.0', '吉田隼', '友道', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(7, 'タイトルホルダー', '牡', '4', '57.0', '横山和', '栗田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(7, 'ボッケリーニ', '牡', '6', '57.0', '浜中', '池江', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(8, 'ブレークアップ', '牡', '4', '57.0', '戸崎圭', '黒岩', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(8, 'ディープボンド', '牡', '5', '57.0', '川田', '大久保', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime'));

INSERT INTO tokyo_yushun
(
	kaisu,
	wakuban,
	bamei,
	seibetu,
	barei,
	kinryo,
	kisyu,
	kyusya,
	createdate,
	updatedate
)
VALUES
(88, 1, 'エフフォーリア', '牡', '3', '57.0', '横山武', '鹿戸', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 1, 'ヴィクティファルス', '牡', '3', '57.0', '池添', '池添学', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 2, 'タイムトゥヘヴン', '牡', '3', '57.0', '石橋脩', '戸田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 2, 'レッドジェネシス', '牡', '3', '57.0', '横山典', '友道', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 3, 'ディープモンスター', '牡', '3', '57.0', '武豊', '池江', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 3, 'バジオウ', '牡', '3', '57.0', '大野', '田中博', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 4, 'グラティアス', '牡', '3', '57.0', '松山', '加藤征', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 4, 'ヨーホーレイク', '牡', '3', '57.0', '川田', '友道', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 5, 'ラーゴム', '牡', '3', '55.0', '浜中', '斉藤崇', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 5, 'シャフリヤール', '牡', '3', '57.0', '福永', '藤原英', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 6, 'ステラヴェローチェ', '牡', '3', '57.0', '吉田隼', '須貝', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 6, 'ワンダフルタウン', '牡', '3', '57.0', '和田竜', '高橋忠', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 7, 'グレートマジシャン', '牡', '3', '57.0', '戸崎圭', '宮田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 7, 'タイトルホルダー', '牡', '3', '57.0', '田辺', '栗田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 8, 'アドマイヤハダル', '牡', '3', '57.0', 'Ｍデムーロ', '大久保', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 8, 'サトノレイナス', '牝', '3', '55.0', 'ルメール', '国枝', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 8, 'バスラットレオン', '牡', '3', '57.0', '藤岡佑', '矢作', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime'));