import React from 'react'

async function fetchListings() {
  const response = await fetch('http://localhost:6001/search')
  if (!response.ok) throw new Error(response.statusText)
  return await response.json()
}

export default async function Listings() {
  const listings = await fetchListings()
  return (
    <div>
      {JSON.stringify(listings, null, 2)}
    </div>
  )
}