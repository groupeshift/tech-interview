<script setup lang="ts">
import { computed, ref } from 'vue'
import { useRouter } from 'vue-router'
import { useBookStore } from '@/stores/book'
import BookCover from '@/components/book/BookCover.vue'
import BookCoverAdd from '@/components/book/BookCoverAdd.vue'
import Button, { ButtonStylingMode } from '@/components/Button.vue'
import InputBase from '@/components/input/InputBase.vue'
import Field from '@/components/field/Field.vue'

const router = useRouter()

const bookStore = useBookStore()
bookStore.fetch()

const searchQuery = ref('')
const isReverseSort = ref(true)

const filteredBooks = computed(() => {
  if(searchQuery.value == null || searchQuery.value == '') {
    return bookStore.books.sort((a, b) =>
      isReverseSort.value
        ? b.title.localeCompare(a.title)
        : a.title.localeCompare(b.title)
      )
  }

  return bookStore.books.filter(
      (book) =>
        book.title.toLowerCase().includes(searchQuery.value.toLowerCase()) ||
        book.author?.toLowerCase().includes(searchQuery.value.toLowerCase())
    ).sort((a, b) =>
      isReverseSort.value
        ? b.title.localeCompare(a.title)
        : a.title.localeCompare(b.title)
    )
  }
)

async function handleDelete(id: number) {
  await bookStore.remove(id)
}

function toggleSortOrder() {
  isReverseSort.value = !isReverseSort.value
}
</script>

<template>
  <div v-if="!bookStore.isLoading" class="flex flex-col gap-4 p-4">
    <div>
      <Field label="Search" class="flex-1">
        <InputBase
          type="text"
          :model-value="searchQuery"
          @update:model-value="(newQuery) => (searchQuery = newQuery)"
        />
      </Field>
      <div class="py-4">
        <Button
          :styling-mode="ButtonStylingMode.Primary"
          @click="toggleSortOrder"
        >
          Sort {{ isReverseSort ? 'A-Z' : 'Z-A' }}
        </Button>
      </div>
      <div class="flex flex-row flex-wrap gap-4 pt-5">
        <div
          v-for="book in filteredBooks"
          :key="book.id"
          class="relative group cursor-pointer"
        >
          <Button
            class="absolute bottom-3 right-3 z-10 hidden group-hover:flex"
            :styling-mode="ButtonStylingMode.Danger"
            @click="handleDelete(book.id)"
            >Delete</Button
          >
          <BookCover
            :key="book.id"
            class="cursor-pointer"
            :book="book"
            @click="router.push({ name: 'book_update', params: { id: book.id } })"
          />
        </div>
        <BookCoverAdd
          @click="router.push({ name: 'book_create' })"
        />
      </div>
    </div>
  </div>
  <div v-else>Chargement...</div>
</template>
