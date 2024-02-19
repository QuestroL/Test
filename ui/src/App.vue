<template>
  <AppHeader/>
  <AppFilter 
  @set-filter="setFilter"
  />
  <AddComment v-if="activeSwitch === 'Add Comment'"/>
  <CommentList v-else/>

</template>

<script lang="ts">
import { defineComponent } from 'vue';
import AppHeader from './components/AppHeader.vue';
import AddComment from './components/AddComment.vue'
import AppFilter from './components/AppFilter.vue'
import CommentList from  './components/CommentList.vue'
interface State{
  activeSwitch: string;
}

export default defineComponent({
  name: 'App',
  components: {
    AppHeader,
    AddComment,
    CommentList,
    AppFilter
},

data(): State
{
  return{
    activeSwitch: 'Add Comment',
  };
},

methods: {
  setFilter(item: string) {
      this.activeSwitch = item
    }
}
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #c52002;
  margin-top: 60px;
}
</style>
