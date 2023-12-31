﻿'use server'

import {Auction, PagedResult} from "@/types";
import {getTokenWorkaround} from "@/app/actions/authActions";
import {fetchWrapper} from "@/lib/fetchWrapper";

export async function getData(query: string): Promise<PagedResult<Auction>> {
  return await fetchWrapper.get(`search${query}`)
}

export async function UpdateAuctionTest() {
  const data = {
    description: "test123",
    serialNumber: "test123",
  }
  
  const token = await getTokenWorkaround()
  
  const response = await fetch(`http://localhost:6001/auctions/ec6c830a-b6e9-4a07-8560-533bc08e3d07`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + token?.access_token
      
    },
    body: JSON.stringify(data)
  })
  
  if (!response.ok) return {status: response.status, message: response.statusText}
  
  return response.statusText
}