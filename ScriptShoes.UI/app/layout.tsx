import './globals.css';
import type { Metadata } from 'next';
import { Montserrat } from 'next/font/google';
import Providers from '../utils/providers';

const inter = Montserrat({ subsets: ['latin'] });

export const metadata: Metadata = {
  title: 'ScriptShoes',
  description: 'Simple e-commerce shop',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return <Providers font={inter.className}>{children}</Providers>;
}
