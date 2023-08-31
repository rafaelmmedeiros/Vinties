import Search from "@/app/nav/Search";
import Logo from "@/app/nav/Logo";

export default function NavBar() {
  return (
    <header className={'sticky top-0 flex justify-between p-5 items-center shadow-md'}>
      <Logo/>
      <Search/>
      <div>
        Login
      </div>
    </header>
  )
}