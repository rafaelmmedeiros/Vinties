import {SiBandsintown} from "react-icons/si";

export default function NavBar() {
  return (
    <header className={'sticky top-0 flex justify-between p-5 items-center shadow-md'}>
      <div className={'flex items-center gap-2 text-3xl font-semibold text-orange-500'}>
        <SiBandsintown size={36}/>
        <div>Vinties Auctions</div>
      </div>
      <div>
        Search
      </div>
      <div>
        Login
      </div>
    </header>
  )
}