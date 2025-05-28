import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  /* config options here */
};

import * as dotenv from 'dotenv';
// if (process.env.NODE_ENV === 'production') {
//   dotenv.config({ path: '.env.prod' });
// } else {
  dotenv.config({ path: '.env.local' });
// }

export default nextConfig;
