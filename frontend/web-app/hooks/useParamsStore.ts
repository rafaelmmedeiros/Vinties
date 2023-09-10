﻿import {create} from "zustand";

type State = {
  pageNumber: number
  pageSize: number
  pageCount: number
  searchTerm: string
  searchValue: string
  orderBy: string
  filterBy: string
  seller?: string
  winner?: string
}

type Actions = {
  setParams: (params: Partial<State>) => void
  reset: () => void
  setSearchValue: (searchValue: string) => void
}

const initialState: State = {
  pageNumber: 1,
  pageSize: 16,
  pageCount: 1,
  searchTerm: '',
  searchValue: '',
  orderBy: 'brand',
  filterBy: 'live',
  seller: undefined,
  winner: undefined
}

export const useParamsStore = create<State & Actions>()(
  (set, get) => ({
    ...initialState,
    setParams: (newParams: Partial<State>) =>
      set((state) => {
        if (newParams.pageNumber) {
          return {
            ...state, pageNumber: newParams.pageNumber
          }
        } else {
          return {
            ...state, ...newParams, pageNumber: 1
          }
        }
      }),

    reset: () => set(initialState),
    setSearchValue: (value: string) => set({searchValue: value})
  }))