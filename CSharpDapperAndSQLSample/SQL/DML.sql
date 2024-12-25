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
    umaban,
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
(88, 1, 1, 'エフフォーリア', '牡', '3', '57.0', '横山武', '鹿戸', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 1, 2, 'ヴィクティファルス', '牡', '3', '57.0', '池添', '池添学', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 2, 3, 'タイムトゥヘヴン', '牡', '3', '57.0', '石橋脩', '戸田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 2, 4, 'レッドジェネシス', '牡', '3', '57.0', '横山典', '友道', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 3, 5, 'ディープモンスター', '牡', '3', '57.0', '武豊', '池江', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 3, 6, 'バジオウ', '牡', '3', '57.0', '大野', '田中博', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 4, 7, 'グラティアス', '牡', '3', '57.0', '松山', '加藤征', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 4, 8, 'ヨーホーレイク', '牡', '3', '57.0', '川田', '友道', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 5, 9, 'ラーゴム', '牡', '3', '55.0', '浜中', '斉藤崇', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 5, 10, 'シャフリヤール', '牡', '3', '57.0', '福永', '藤原英', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 6, 11, 'ステラヴェローチェ', '牡', '3', '57.0', '吉田隼', '須貝', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 6, 12, 'ワンダフルタウン', '牡', '3', '57.0', '和田竜', '高橋忠', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 7, 13, 'グレートマジシャン', '牡', '3', '57.0', '戸崎圭', '宮田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 7, 14, 'タイトルホルダー', '牡', '3', '57.0', '田辺', '栗田', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 8, 15, 'アドマイヤハダル', '牡', '3', '57.0', 'Ｍデムーロ', '大久保', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 8, 16, 'サトノレイナス', '牝', '3', '55.0', 'ルメール', '国枝', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(88, 8, 17, 'バスラットレオン', '牡', '3', '57.0', '藤岡佑', '矢作', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime'));

INSERT INTO dubai_sheema_classic
(
	kaisu,
	wakuban,
    umaban,
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
(25, 1, 8, 'ウエストオーバー', '牡', '4', '56.5', 'Ｒ．ムーア', 'Ｒ．ベケット', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 2, 9, 'ザグレイ', '牡', '4', '56.5', 'Ｃ．スミヨン', 'Ｙ．バルブロ', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 3, 4, 'ロシアンエンペラー', 'セ', '6', '57.0', 'Ａ．サナ', 'Ｄ．ホワイト', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 4, 10, 'ウインマリリン', '牝', '6', '55.0', 'Ｄ．レーン', '手塚貴久', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 5, 1, ' ボタニク', 'セ', '5', '57.0', 'Ｍ．バルザローナ', 'Ａ．ファーブル', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 6, 7, 'イクイノックス', '牡', '4', '56.5', 'Ｃ．ルメール ', '木村哲也', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 7, 6, 'シャフリヤール', '牡', '5', '57.0', 'Ｃ．デムーロ', '藤原英昭', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 8, 2, 'モスターダフ', '牡', '5', '57.0', 'Ｊ．クローリー', 'Ｊ＆Ｔ．ゴスデン', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 9, 5, 'セニョールトーバ', 'セ', '5', '57.0', 'Ｌ．デットーリ', 'Ｃ．ファウンズ', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime')),
(25, 10, 3,'レベルスロマンス', 'セ', '5', '57.0', 'Ｗ．ビュイック', 'Ｃ．アップルビー', datetime(CURRENT_TIMESTAMP,'localtime'), datetime(CURRENT_TIMESTAMP,'localtime'));