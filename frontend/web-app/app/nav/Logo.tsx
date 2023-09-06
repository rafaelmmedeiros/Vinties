'use client'

import React from "react";
import {SiBandsintown} from "react-icons/si";
import {useParamsStore} from "@/hooks/useParamsStore";
import {usePathname, useRouter} from "next/navigation";

export default function Logo() {
  const reset = useParamsStore(state => state.reset)
  const router = useRouter()
  const pathname = usePathname()
  
  function doReset() {
    if (pathname !== '/') {
      router.push('/')
    }
    reset();
  }
  
  return (
    <div onClick={doReset} className={'cursor-pointer flex items-center gap-2 text-3xl font-semibold text-orange-500'}>
      <SiBandsintown size={36}/>
      <div>Vinties Auctions</div>
    </div>
  )
}