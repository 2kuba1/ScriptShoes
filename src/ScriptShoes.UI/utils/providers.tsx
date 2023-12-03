'use client';

import Footer from '@/components/footer';
import Navbar from '@/components/navbar/navbar';
import useThemeStore from '@/stores/themeStore';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import { ReactQueryStreamedHydration } from '@tanstack/react-query-next-experimental';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { useState } from 'react';

interface Props {
  children: React.ReactNode;
  font: string;
}

export default function Providers({ children, font }: Props) {
  const { theme } = useThemeStore();
  const [client] = useState(new QueryClient());

  return (
    <QueryClientProvider client={client}>
      <html lang='en' className={theme}>
        <body className={font}>
          <Navbar />
          <ReactQueryStreamedHydration>{children}</ReactQueryStreamedHydration>
          <ReactQueryDevtools initialIsOpen={false} />
          <Footer />
        </body>
      </html>
    </QueryClientProvider>
  );
}
