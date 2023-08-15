import React from 'react'
import AuctionCard from "@/app/auctions/AuctionCard";

async function fetchListings() {
  const response = await fetch('http://localhost:6001/search')
  if (!response.ok) throw new Error(response.statusText)
  return await response.json()
}

export default async function Listings() {
  const listings = await fetchListings()
  return (
    <div>
      {listings && listings.results.map((auction: any) => (
        <AuctionCard auction={auction} key={auction.id}/>
      ))}
    </div>
  )
}