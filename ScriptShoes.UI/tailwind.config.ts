import type { Config } from 'tailwindcss';

const config: Config = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        gray: '#222',
        white: '#DFDFDF',
        yellow: '#FCBF49',
        orange: '#F77F00',
        'dark-blue': '#003049',
      },
      minHeight: {
        'without-nav': 'calc(100vh - 4rem)',
      },
    },
  },
  plugins: [],
};
export default config;
