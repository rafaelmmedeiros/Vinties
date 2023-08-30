'use server'

import {Auction, PagedResult} from "@/types";

export async function getAuctions(pageNumber: number = 1): Promise<PagedResult<Auction>> {
  const response = await fetch(`http://localhost:6001/search?pageSize=1&pageNumber=${pageNumber}`)
  if (!response.ok) throw new Error(response.statusText)
  return await response.json()
}