<script setup lang="ts">
import BookCoverBase from './BookCoverBase.vue'

defineProps<{
  book: Book
}>()
</script>

<template>
  <BookCoverBase>
    <div>
      <span class="font-bold text-ellipsis line-clamp-3" :title="book.title">{{ book.title }}</span>
      <span class="text-sm text-white/50 line-clamp-1" :title="book.author">{{ book.author }}</span>
      <span v-if="book.loaned" class="text-sm text-red line-clamp-1" :title="book.loaned">Loué</span>
    </div>
  </BookCoverBase>
</template>
