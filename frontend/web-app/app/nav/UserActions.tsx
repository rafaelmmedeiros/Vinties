﻿'use client'

import React from "react";
import {Dropdown} from "flowbite-react";
import {User} from "next-auth";
import {HiOutlineCog6Tooth, HiUser} from "react-icons/hi2";
import Link from "next/link";
import {AiFillTrophy, AiOutlineLogout} from "react-icons/ai";
import {GiGuitar} from "react-icons/gi";
import {signOut} from "next-auth/react";
import {usePathname, useRouter} from "next/navigation";
import {useParamsStore} from "@/hooks/useParamsStore";

type Props = {
  user: User
}

export default function UserActions({user}: Props) {
  const router = useRouter()
  const pathname = usePathname()
  const setParams = useParamsStore(state => state.setParams)
  
  function setWinner() {
    setParams({winner: user.username, seller: undefined})
    if(pathname !== '/') {
      router.push('/')
    }
  }

  function setSeller() {
    setParams({seller: user.username, winner: undefined})
    if(pathname !== '/') {
      router.push('/')
    }
  }
  
  return (
    <Dropdown
      inline
      label={`Welcome ${user.name}`}
    >
      <Dropdown.Item icon={HiUser} onClick={setSeller}>
        My auctions
      </Dropdown.Item>
      
      <Dropdown.Item icon={AiFillTrophy} onClick={setWinner}>
        Auctions won
      </Dropdown.Item>
      
      <Dropdown.Item icon={GiGuitar}>
        <Link href={'/auctions/create'}>Sell a vintie</Link>
      </Dropdown.Item>
      
      <Dropdown.Item icon={HiOutlineCog6Tooth}>
        <Link href={'/session'}>Session (dev)</Link>
      </Dropdown.Item>
      
      <Dropdown.Divider/>
      
      <Dropdown.Item icon={AiOutlineLogout}
        onClick={() => signOut({callbackUrl: '/'})}
      >
        Sign out
      </Dropdown.Item>
      
      <Dropdown.Divider/>
    </Dropdown>
  )
}