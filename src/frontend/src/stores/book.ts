import { ref } from 'vue'
import { defineStore } from 'pinia'
import axios from 'axios'
import { sleep } from '@/utils/sleep'

export const useBookStore = defineStore('book', () => {
  const books = ref<Book[]>([])
  const isLoading = ref(false)

  return {
    books,
    isLoading,

    fetch: async () => {
      isLoading.value = true
  
      const [bookResponse, loanResponse] = await Promise.all([
        axios.get<Book[]>('/book'),
        axios.get<Loan[]>('/loan')
      ])
  
      const loanedBookIds = new Set(loanResponse.data.map((loan) => loan.bookId))
  
      books.value = bookResponse.data.map((book) => ({
        ...book,
        loaned: loanedBookIds.has(book.id),
      }))

      await sleep(500) // Peut être utilisé pour tester le "chargement".
  
      isLoading.value = false
    },
    create: async (book: Book) => {
      const { data: id } = await axios.post('/book', book)
      books.value.push(book)
      return id
    },
    update: async (book: Book) => {
      await axios.put(`/book/${book.id}`, book)
      const index = books.value.findIndex((b) => b.id === book.id)
      if (index !== -1) {
        books.value[index] = book
      }
    },
    remove: async (id: number) => {
      console.log(id)
      await axios.delete(`/book/${id}`)
      const index = books.value.findIndex((b) => b.id === id)
      if (index !== -1) {
        books.value.splice(index, 1)
      }
    }
  }
})

export interface Book {
  id: number
  title: string
  author: string
  loaned: boolean
}

export interface Loan {
  id: number
  memberId: number
  bookId: number
  loanDate: Date
  returnDate: Date | undefined
}
