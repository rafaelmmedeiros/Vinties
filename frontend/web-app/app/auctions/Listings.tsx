'use client'

import React, {useEffect, useState} from 'react'
import AuctionCard from "@/app/auctions/AuctionCard";
import AppPagination from "@/app/components/AppPagination";
import {Auction} from "@/types";
import {getAuctions} from "@/app/actions/auctionActions";
import Filters from "@/app/auctions/Filters";

export default function Listings() {
  const [auctions, setAuctions] = useState<Auction[]>([])
  const [pageCount, setPageCount] = useState(0)
  const [pageNumber, setPageNumber] = useState(1)
  const [pageSize, setPageSize] = useState(16)
  
  useEffect(() => {
    getAuctions(pageNumber, pageSize).then((data: any) => {
      setAuctions(data.results)
      setPageCount(data.pageCount)
    })
  }, [pageNumber, pageSize])
  
  if (auctions.length === 0) {
    return (
      <div className={'text-center'}>
        <h3 className={'text-2xl font-bold'}>Loading...</h3>
      </div>
    )
  }
  
  return (
    <>
      <Filters pageSize={pageSize} setPageSize={setPageSize}/>
      <div className={'grid grid-cols-4 gap-6'}>
        {auctions.map((auction: any) => (
          <AuctionCard auction={auction} key={auction.id}/>
        ))}
      </div>
      <div className={'flex justify-center mt-4'}>
        <AppPagination currentPage={pageNumber} pageCount={pageCount} pageChanged={setPageNumber}/>
      </div>
    </>
  )
}