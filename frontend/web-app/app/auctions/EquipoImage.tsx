'use client'

import React from "react";
import Image from "next/image";

type Props = {
  imageUrl: string
}

export default function EquipoImage({imageUrl}: Props) {
  const [isLoading, setLoading] = React.useState(true)
  return (
    <div>
      <Image
        src={imageUrl}
        alt={'image'}
        fill
        priority
        className={
          `object-cover group-hover:opacity-75 transition duration-150 ease-in-out 
          ${isLoading ? 'grayscale blur-2xl scale-110' : 'grayscale-0 blur-0 scale-100'}'}`}
        sizes={'(max-width: 768px) 100vw, (max-width: 1200px) 50vw'}
        onLoadingComplete={() => setLoading(false)}
      />
    </div>
  )
}