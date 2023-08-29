export type PagedResult<T> = {
  results: T[]
  pageCount: number
  totalCount: number
}

export type Auction = {
  seller: string
  winner?: string
  reservePrice: number
  soldAmount: number
  currentHighBid: number
  created: string
  updated: string
  auctionEnd: string
  status: string
  model: string
  brand: string
  description: string
  type: string
  serialNumber: string
  year: number
  color: string
  imageUrl: string
  id: string
}