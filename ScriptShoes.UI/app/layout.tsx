import './globals.css';
import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import Providers from './providers';

const inter = Inter({ subsets: ['latin'] });

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
