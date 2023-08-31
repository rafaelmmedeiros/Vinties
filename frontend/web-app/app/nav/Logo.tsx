'use client'

import React from "react";
import {SiBandsintown} from "react-icons/si";
import {useParamsStore} from "@/hooks/useParamsStore";

export default function Logo() {
  const reset = useParamsStore(state => state.reset)
  return (
    <div onClick={reset} className={'cursor-pointer flex items-center gap-2 text-3xl font-semibold text-orange-500'}>
      <SiBandsintown size={36}/>
      <div>Vinties Auctions</div>
    </div>
  )
}