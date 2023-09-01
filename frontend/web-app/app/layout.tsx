import './globals.css'
import type {Metadata} from 'next'
import NavBar from "@/app/nav/NavBar";
import React from "react";

export const metadata: Metadata = {
  title: 'Vinties',
  description: 'Vintage music equipos',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>
        <NavBar />
        <main className={'container mx-auto px-5 pt-10'}>
          {children}
        </main>
      </body>
    </html>
  )
}
