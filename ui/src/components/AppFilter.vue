<template>
   <aside class="app-filters">
        <section class="toggle-group">
          <button class="button button--primary" @click="setFilter('Add Comment')" >Add Comment</button>
          <button class="button" @click="setFilter('All Comments')" >All Comments</button>
        </section>
      </aside>
</template>

<script lang="ts">
import { defineComponent } from 'vue';


export default defineComponent({
  methods: {
    setFilter(item: string) {
      this.$emit('setFilter', item)
    }
  },
  emits: {
    setFilter: (item: string) => item
  }
})
</script>

<style>
</style>