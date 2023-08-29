import React from 'react'
import AuctionCard from "@/app/auctions/AuctionCard";
import {Auction, PagedResult} from "@/types";

async function fetchAuctionList(): Promise<PagedResult<Auction>> {
  const response = await fetch('http://localhost:6001/search')
  if (!response.ok) throw new Error(response.statusText)
  return await response.json()
}

export default async function Listings() {
  const auctions = await fetchAuctionList()
  return (
    <div className={'grid grid-cols-4 gap-6'}>
      {auctions && auctions.results.map((auction: any) => (
        <AuctionCard auction={auction} key={auction.id}/>
      ))}
    </div>
  )
}