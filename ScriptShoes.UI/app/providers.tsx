'use client';

import Navbar from '@/components/navbar/navbar';
import useThemeStore from '@/stores/themeStore';

interface Props {
  children: React.ReactNode;
  font: string;
}

export default function Providers({ children, font }: Props) {
  const { theme } = useThemeStore();

  return (
    <html lang='en' className={theme}>
      <body className={font}>
        <Navbar />
        {children}
      </body>
    </html>
  );
}
