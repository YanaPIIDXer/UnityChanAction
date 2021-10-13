<template>
  <div id="app">
    <unity src="unitybuild/Build/unitybuild.json" unityLoader="unitybuild/Build/UnityLoader.js"
        v-bind="{
                        width: 1024,
                        height: 500,
                        hideFooter: true,
                        externalProcess: true,
                        module: { TOTAL_STACK: 6 * 1024 * 1024 },
                }" />
    <h2>操作方法</h2>
    <table border="1">
      <td>上下左右、WSAD</td><td>移動</td>
      <td>Zキー、Xキー、Cキー</td>><td>攻撃（Zキーの攻撃は３段目まで）</td>
    </table>
  </div>
</template>

<script>
import Unity from 'vue-unity-webgl';

export default {
  name: 'App',
    components: {
        Unity,
    }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
