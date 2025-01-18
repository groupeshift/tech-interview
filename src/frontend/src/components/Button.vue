<script setup lang="ts">
withDefaults(
  defineProps<{
    stylingMode: ButtonStylingMode
    disabled?: boolean
  }>(),
  {
    stylingMode: ButtonStylingMode.Default,
    disabled: false
  }
)

const defaultStyleClasses = 'bg-white active:bg-gray-200 hover:bg-gray-100'
const primaryStyleClasses = 'bg-green-500 active:bg-green-600 hover:bg-green-400'
const dangerStyleClasses = 'bg-red-500 active:bg-red-600 hover:bg-red-400'
const disabledClasses = 'bg-gray-300 text-gray-500 cursor-not-allowed'
</script>

<script lang="ts">
export enum ButtonStylingMode {
  Default = 'default',
  Primary = 'primary',
  Danger = 'Danger'
}
</script>

<template>
  <button
    class="px-4 py-2 transition-all rounded active:transition-none"
    :class="{
      [defaultStyleClasses]: stylingMode === ButtonStylingMode.Default && !disabled,
      [primaryStyleClasses]: stylingMode === ButtonStylingMode.Primary && !disabled,
      [dangerStyleClasses]: stylingMode === ButtonStylingMode.Danger && !disabled,
      [disabledClasses]: disabled
    }"
  >
    <slot />
  </button>
</template>
