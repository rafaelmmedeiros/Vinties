﻿import Search from "@/app/nav/Search";
import Logo from "@/app/nav/Logo";
import LoginButton from "@/app/nav/LoginButton";
import {getCurrentUser} from "@/app/actions/authActions";
import UserActions from "@/app/nav/UserActions";

export default async function NavBar() {
  const user = await getCurrentUser()
  return (
    <header className={'sticky top-0 flex justify-between p-5 items-center shadow-md'}>
      <Logo/>
      <Search/>
      {user ? (
        <UserActions/>
      ) : (
        <LoginButton/>
      )}
    </header>
  )
}