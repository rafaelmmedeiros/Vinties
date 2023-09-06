'use client'

import React from "react";
import {Dropdown} from "flowbite-react";
import {User} from "next-auth";
import {HiOutlineCog6Tooth, HiUser} from "react-icons/hi2";
import Link from "next/link";
import {AiFillTrophy, AiOutlineLogout} from "react-icons/ai";
import {GiGuitar} from "react-icons/gi";
import {signOut} from "next-auth/react";

type Props = {
  user: Partial<User>
}

export default function UserActions({user}: Props) {
  return (
    <Dropdown
      inline
      label={`Welcome ${user.name}`}
    >
      <Dropdown.Item icon={HiUser}>
        <Link href={'/'}>My auctions</Link>
      </Dropdown.Item>
      <Dropdown.Item icon={AiFillTrophy}>
        <Link href={'/'}>Auctions won</Link>
      </Dropdown.Item>
      <Dropdown.Item icon={GiGuitar}>
        <Link href={'/'}>Sell a vintie</Link>
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