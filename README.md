# SmoothCamera

# Japanese

1. SmoothCamera とは？

SmoothCamera はカメラの移動時に動的に画質クオリティを下げることで、
体感上の FPS を向上させる Mod です。

一般に、低 FPS からくるラグはカメラの移動時に実感することが多く、
逆にカメラの移動時には、多少の画質の低下は気にならなくなることが多いです。

このことを利用し、カメラの移動時のみ一時的に画質のクオリティを下げることで、
画質の低下を気にすることなく、スムーズなカメラ操作を行うことが可能となります。

2. どれくらい効果があるのか？

マシンの性能やゲーム上の街の発展状況によって効果は異なります。
もし、オプション画面の画質設定欄でShadow quality や Detail of object の設定を低設定にして
FPS の向上が得られるなら、この MOD による効果が期待できます。

手元の環境では、後述の設定パターン A) で約 20% B) で約 50% C) で約 70% 程度の速度向上が確認できました。

3. 設定項目

・Default shadow quality
静止状態での影のクオリティです。

・Light weight shadow quality
カメラ移動時の影のクオリティです。通常、Default shadow quality よりも低い値を設定します。

・Default level of detail
静止状態でのオブジェクトのクオリティです。

・Light weight level of detail
カメラ移動時のオブジェクトのクオリティです。通常、Default level of detail よりも低い値を設定します。

・Return delay frame
カメラが再び静止したときに、静止状態のクオリティに戻すまでの遅延フレームを示します。
カメラが断続的に移動するケースにおいて、低画質と高画質が高い頻度で切り替わるのを防ぎます。

・Apply threashold FPS
静止状態で設定の FPS を上回るような状態では、移動しても低画質モードに移行しないようにします。

4. 設定値のパターン

 A) Default shadow quality      : High
    Light weight shadow quality : High
    Default level of detail     : Excellent
    Light weight level of detail: Low

Light weight level of detail のみ低画質モードにします。
移動時の画質の変化はあまり気にならない程度で、ある程度のFPS向上が見込まれます。

 B) Default shadow quality      : High
    Light weight shadow quality : None
    Default level of detail     : Excellent
    Light weight level of detail: Excellent

Light weight shadow quality のみ低画質モード(影無し)にします。
移動時はそれなりに画質の低下が認識されますが、結構なFPS向上が見込まれます。

 C) Default shadow quality      : High
    Light weight shadow quality : None
    Default level of detail     : Excellent
    Light weight level of detail: Low

Light weight shadow quality と Light weight level of detail の両方を低画質にします。
移動時はそれなりに画質の低下が認識されますが、かなりのFPS向上が見込まれます。

5. 制限事項

他のカメラ制御系 MOD と干渉するかもしれません。
Camera positions utility mod と共存できるようには作っています。

画質設定オプション項目の、
・Shadow quality 
・Shadow distance
・Object detail
の設定値はこの MOD によって上書きされます。

Ultimate level of detail の設定と競合する可能性があります。
(全て Game defaultに設定している限りは問題ありません)

