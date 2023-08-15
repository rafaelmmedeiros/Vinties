
type Props = {
  auction: any
}

export default function AuctionCard({auction}: Props) {
  return (
    <div>
      {auction.brand}
    </div>
  )
}