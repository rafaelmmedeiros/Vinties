/** @type {import('next').NextConfig} */
const nextConfig = {
  experimental: {
    serverActions: true
  },
  images: {
    domains: ['1.bp.blogspot.com', 'res.cloudinary.com', 'www.gibson.com', 'cdn.pixabay.com', 'placeimg.com', 'images.ctfassets.net', 'ranguitars.com', 'images.reverb.com', 'cdn.ecommercedns.uk', 'images.unsplash.com']
  }
}

module.exports = nextConfig
