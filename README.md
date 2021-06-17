# SmoothCamera

日本語の解説は後半にあります。

# English

1. What is SmoothCamera?

SmoothCamera is the MOD which improve your game practical FPS by 
reducing rendering quality only when a camera is moving.

In general, we are tend to feel a laggy when a camera is moving,
otherwise, we couldn't recognize image quality debasement at that time.

SmoothCamera could provide you to a smooth camera operation by 
reducing rendering quality for a temprary period of time only when 
a moving.

Introduction movie: [https://www.youtube.com/watch?v=pDkcILze7oA](https://www.youtube.com/watch?v=pDkcILze7oA)


2. How to install?

Make a "SmoothCamera" directory under 
```言語:タイトル
"%LOCALAPPDATA%\Colossal Order\Cities_Skylines\Addons\Mods
```

Then, deploy following files.
 - 0Harmony.dll
 - SmoothCamera.dll

And make sure to enable this mod on Contents manager.

3. How efficient?

Honesty, it depends on your environment. (Machine power, scale of your city, number of mod/asset)
If your city has a margin for image quality debasement by default option setting (Shadow quality or Detail of object),
you can expect to improve a FPS.

4. Setting UI
 
- Default shadow quality:
  - Shadow quality when camera is stopped.

- Light weight shadow quality:
  - Shadow quality when camera is moving.

- Default level of detail:
  - Object LOD quality when camera is stopped.

- Light weight level of detail:
  - Object LOD quality when camera is moving.

- Return delay frame:
  - The delay frame count for returning default quality.
  - This prevent to switch an image quality frequently.

- Apply only when FPS is slower than this value:
  - This value is a threashold to prevent to switch a low quality at the time of high FPS.
  - Make sure to set 'None' if you use a speedslider MOD.

- Don't apply when a FreeCamera mode is enabled:
  - If you want to apply at free camera mode, check it.

5. Setting pattern

### Pattern A
| Setting | Value |
|:-:|:-:|
|Default shadow quality|High|
|Light weight shadow quality|High|
|Default level of detail|Excellent|
|Light weight level of detail|Low|

Apply only 'Light weight level of detail'.
You couldn't recognize almost image debasement, and you can get some FPS improvement.

### Pattern B
| Setting | Value |
|:-:|:-:|
|Default shadow quality|High|
|Light weight shadow quality|None|
|Default level of detail|Excellent|
|Light weight level of detail|Excellent|

Apply only 'Light weight shadow quality'.
You can recognize an image debasement, but you can get a big FPS imrovement.

### Pattern C
| Setting | Value |
|:-:|:-:|
|Default shadow quality|High|
|Light weight shadow quality|None|
|Default level of detail|Excellent|
|Light weight level of detail|Low|

Apply both 'Light weight level of detail' and 'Light weight shadow quality'.
You can also recognize an image debasement, but you can get a significant FPS imrovement.


6. Limitation

This mod could be an compatible issue with other camera MOD.
I confirm 'Camera positions utility mod' has a compatible.

If you use a speedslider mod, make sure to set 'None' for Apply only when FPS is slower than this value,
because FPS calculation will be wrong.

The following settings on default setting UI is overwritten by this mod.
- Shadow quality 
- Shadow distance
- Object detail

There is a possibility to have an any issue with 'Ultimate level of detail' mod.
Set all parameters to 'Game default'

This mod patches CameraController.UpdateCurrentPosition function by using Harmony library.
So if other mod also patches this function, this mod couldn't work toghter.

7. Concerning point

I found some FPS down at the twinkling of Level of detail switching.
Although it is a slightly on my environment, you might aware it if you use a 
low spec CPU or your city has a large amout of objects.


## Japanese

1. SmoothCamera とは？

SmoothCamera はカメラの移動時に動的に画質クオリティを下げることで、
体感上の FPS を向上させる Mod です。

一般に、低 FPS からくるラグはカメラの移動時に実感することが多く、
逆にカメラの移動時には、多少の画質の低下は気にならなくなることが多いです。

このことを利用し、カメラの移動時のみ一時的に画質のクオリティを下げることで、
画質の低下を気にすることなく、スムーズなカメラ操作を行うことが可能となります。

紹介動画: [https://www.youtube.com/watch?v=pDkcILze7oA](https://www.youtube.com/watch?v=pDkcILze7oA)

2. インストール方法
```言語:タイトル
"%LOCALAPPDATA%\Colossal Order\Cities_Skylines\Addons\Mods
```
以下に SmoothCamera
ディレクトリを作成し、以下のファイルを配置してください。

 - 0Harmony.dll
 - SmoothCamera.dll
 
その後、Cities Skylines を起動し、コンテンツマネージャーから MOD を有効にしてください。

3. どれくらい効果があるのか？

マシンの性能やゲーム上の街の発展状況によって効果は異なります。
もし、オプション画面の画質設定欄でShadow quality や Detail of object の設定を低設定にして
FPS の向上が得られるなら、この MOD による効果が期待できます。

手元の環境では、後述の設定パターン A) で約 20% B) で約 50% C) で約 70% 程度の速度向上が確認できました。

4. 設定項目

- Default shadow quality
  - 静止状態での影のクオリティです。

- Light weight shadow quality
  - カメラ移動時の影のクオリティです。通常、Default shadow quality よりも低い値を設定します。

- Default level of detail
  - 静止状態でのオブジェクトのクオリティです。

- Light weight level of detail
  - カメラ移動時のオブジェクトのクオリティです。通常、Default level of detail よりも低い値を設定します。

- Return delay frame
  - カメラが再び静止したときに、静止状態のクオリティに戻すまでの遅延フレームを示します。
  - カメラが断続的に移動するケースにおいて、低画質と高画質が高い頻度で切り替わるのを防ぎます。

- Apply only when FPS is slower than this value
  - 静止状態で設定の FPS を上回るような状態では、移動しても低画質モードに移行しないようにします。
  - Speedslider を使っている場合、FPS の計算がおかしくなるため、None を設定してください。

- Don't apply when a FreeCamera mode is enabled:
  - Free camera モードでこの機能を無効にした場合はチェックを入れてください。

5. 設定値のパターン

### Pattern A
| Setting | Value |
|:-:|:-:|
|Default shadow quality|High|
|Light weight shadow quality|High|
|Default level of detail|Excellent|
|Light weight level of detail|Low|

Light weight level of detail のみ低画質モードにします。
移動時の画質の変化はあまり気にならない程度で、ある程度のFPS向上が見込まれます。

### Pattern B
| Setting | Value |
|:-:|:-:|
|Default shadow quality|High|
|Light weight shadow quality|None|
|Default level of detail|Excellent|
|Light weight level of detail|Excellent|

Light weight shadow quality のみ低画質モード(影無し)にします。
移動時はそれなりに画質の低下が認識されますが、結構なFPS向上が見込まれます。

### Pattern C
| Setting | Value |
|:-:|:-:|
|Default shadow quality|High|
|Light weight shadow quality|None|
|Default level of detail|Excellent|
|Light weight level of detail|Low|

Light weight shadow quality と Light weight level of detail の両方を低画質にします。
移動時はそれなりに画質の低下が認識されますが、かなりのFPS向上が見込まれます。

6. 制限事項

他のカメラ制御系 MOD と干渉するかもしれません。
Camera positions utility mod と共存できるようには作っています。

Speedslider を使っている場合、FPS の計算がおかしくなるため、
Apply only when FPS is slower than this value の値を None を設定してください。

画質設定オプション項目の、
・Shadow quality 
・Shadow distance
・Object detail
の設定値はこの MOD によって上書きされます。

Ultimate level of detail の設定と競合する可能性があります。
(全て Game defaultに設定している限りは問題ありません)

内部的には CameraController.UpdateCurrentPosition を
Harmony を使ってパッチしています。
この関数をパッチしている他の MOD が存在していた場合、
競合が発生します。

7. 懸念事項

Level of detail の設定が切り替わる瞬間、若干のパフォーマンスダウンが
測定されました。手元の環境では体感できる程度ではありませんでしたが、
CPU のスペックが低かったり、都市のオブジェクトが多かったりすると、
体感できるレベルになる可能性もあります。

