# SmoothCamera

## Update history

Version 2.0
- Improve Object LOD
- Add Toggle key bind (Default: Ctrl + G)
- Use game setting value as a default quality
- Remove FPS Threashold

Version 1.0
- First release


日本語の解説は後半にあります。

## English

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

If you already subscribe this mod from workshop, unsubscribe it in advance.

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
 
- Light weight shadow quality:
  - Shadow quality when camera is moving.

- Light weight level of detail:
  - Object LOD quality when camera is moving.

- Return delay frame:
  - The delay frame count for returning default quality.
  - This prevent to switch an image quality frequently.

- Toggle Key Code
  - Select key bind pattern to switch this function.

- Don't apply when a FreeCamera mode is enabled:
  - If you want to apply at free camera mode, check it.

5. Limitation

This mod could be an compatible issue with other camera MOD.
I confirm 'Camera positions utility mod' has a compatible.

There is a possibility to have an any issue with 'Ultimate level of detail' mod.
Set all parameters to 'Game default'

This mod patches CameraController.UpdateCurrentPosition function by using Harmony library.
So if other mod also patches this function, this mod couldn't work toghter.


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

すでに Smooth Camera をサブスクライブしている場合は、サブスクリプションを解除します。

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

4. 設定項目

- Light weight shadow quality
  - カメラ移動時の影のクオリティです。

- Light weight level of detail
  - カメラ移動時のオブジェクトのクオリティです。

- Return delay frame
  - カメラが再び静止したときに、静止状態のクオリティに戻すまでの遅延フレームを示します。
  - カメラが断続的に移動するケースにおいて、低画質と高画質が高い頻度で切り替わるのを防ぎます。

- Toggle Key Code
  - 機能の on/off を切り替えるキーのバインドを指定します。

- Don't apply when a FreeCamera mode is enabled:
  - Free camera モードでこの機能を無効にした場合はチェックを入れてください。

5. 制限事項

他のカメラ制御系 MOD と干渉するかもしれません。
Camera positions utility mod と共存できるようには作っています。

Ultimate level of detail の設定と競合する可能性があります。
(全て Game defaultに設定している限りは問題ありません)

内部的には CameraController.UpdateCurrentPosition を
Harmony を使ってパッチしています。
この関数をパッチしている他の MOD が存在していた場合、
競合が発生します。

