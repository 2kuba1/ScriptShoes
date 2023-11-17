'use client';

import Image from 'next/image';
import SearchBar from './searchBar';
import useNavbarStore from '@/stores/navbarStore';
import { AnimatePresence, motion } from 'framer-motion';
import SearchForShoes from './searchForShoes';
import { useDebounce } from 'use-debounce';
import Link from 'next/link';

const Navbar = () => {
  const { isOpened, setIsOpened, searchPhrase } = useNavbarStore();

  const [value] = useDebounce(searchPhrase, 500);

  return (
    <AnimatePresence>
      <div className='relative top-0 w-screen'>
        <nav className='h-16 w-full flex items-center bg-yellow px-2'>
          {isOpened ? (
            <SearchBar />
          ) : (
            <motion.div
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              exit={{ opacity: 1 }}
              className='flex items-center justify-between w-full'
            >
              <Link href='/'>
                <svg
                  width='80'
                  height='64'
                  viewBox='0 0 149 54'
                  fill='none'
                  xmlns='http://www.w3.org/2000/svg'
                >
                  <path
                    d='M10.26 28.764C8.244 28.764 6.312 28.5 4.464 27.972C2.616 27.42 1.128 26.712 0 25.848L1.98 21.456C3.06 22.224 4.332 22.86 5.796 23.364C7.284 23.844 8.784 24.084 10.296 24.084C11.448 24.084 12.372 23.976 13.068 23.76C13.788 23.52 14.316 23.196 14.652 22.788C14.988 22.38 15.156 21.912 15.156 21.384C15.156 20.712 14.892 20.184 14.364 19.8C13.836 19.392 13.14 19.068 12.276 18.828C11.412 18.564 10.452 18.324 9.396 18.108C8.364 17.868 7.32 17.58 6.264 17.244C5.232 16.908 4.284 16.476 3.42 15.948C2.556 15.42 1.848 14.724 1.296 13.86C0.768 12.996 0.504 11.892 0.504 10.548C0.504 9.108 0.888 7.8 1.656 6.624C2.448 5.424 3.624 4.476 5.184 3.78C6.768 3.06 8.748 2.7 11.124 2.7C12.708 2.7 14.268 2.892 15.804 3.276C17.34 3.636 18.696 4.188 19.872 4.932L18.072 9.36C16.896 8.688 15.72 8.196 14.544 7.884C13.368 7.548 12.216 7.38 11.088 7.38C9.96 7.38 9.036 7.512 8.316 7.776C7.596 8.04 7.08 8.388 6.768 8.82C6.456 9.228 6.3 9.708 6.3 10.26C6.3 10.908 6.564 11.436 7.092 11.844C7.62 12.228 8.316 12.54 9.18 12.78C10.044 13.02 10.992 13.26 12.024 13.5C13.08 13.74 14.124 14.016 15.156 14.328C16.212 14.64 17.172 15.06 18.036 15.588C18.9 16.116 19.596 16.812 20.124 17.676C20.676 18.54 20.952 19.632 20.952 20.952C20.952 22.368 20.556 23.664 19.764 24.84C18.972 26.016 17.784 26.964 16.2 27.684C14.64 28.404 12.66 28.764 10.26 28.764Z'
                    fill='black'
                  />
                  <path
                    d='M33.901 28.62C31.813 28.62 29.953 28.2 28.321 27.36C26.689 26.496 25.405 25.308 24.469 23.796C23.557 22.284 23.101 20.568 23.101 18.648C23.101 16.704 23.557 14.988 24.469 13.5C25.405 11.988 26.689 10.812 28.321 9.972C29.953 9.108 31.813 8.676 33.901 8.676C35.941 8.676 37.717 9.108 39.229 9.972C40.741 10.812 41.857 12.024 42.577 13.608L38.221 15.948C37.717 15.036 37.081 14.364 36.313 13.932C35.569 13.5 34.753 13.284 33.865 13.284C32.905 13.284 32.041 13.5 31.273 13.932C30.505 14.364 29.893 14.976 29.437 15.768C29.005 16.56 28.789 17.52 28.789 18.648C28.789 19.776 29.005 20.736 29.437 21.528C29.893 22.32 30.505 22.932 31.273 23.364C32.041 23.796 32.905 24.012 33.865 24.012C34.753 24.012 35.569 23.808 36.313 23.4C37.081 22.968 37.717 22.284 38.221 21.348L42.577 23.724C41.857 25.284 40.741 26.496 39.229 27.36C37.717 28.2 35.941 28.62 33.901 28.62Z'
                    fill='black'
                  />
                  <path
                    d='M45.8106 28.332V8.964H51.1746V14.436L50.4186 12.852C50.9946 11.484 51.9186 10.452 53.1906 9.756C54.4626 9.036 56.0106 8.676 57.8346 8.676V13.86C57.5946 13.836 57.3786 13.824 57.1866 13.824C56.9946 13.8 56.7906 13.788 56.5746 13.788C55.0386 13.788 53.7906 14.232 52.8306 15.12C51.8946 15.984 51.4266 17.34 51.4266 19.188V28.332H45.8106Z'
                    fill='black'
                  />
                  <path
                    d='M61.3106 28.332V8.964H66.9266V28.276L61.3106 28.332ZM64.017 6.264C62.985 6.264 62.145 5.964 61.497 5.364C60.849 4.764 60.525 4.02 60.525 3.132C60.525 2.244 60.849 1.5 61.497 0.900001C62.145 0.3 62.985 0 64.017 0C65.049 0 65.889 0.288001 66.537 0.864002C67.185 1.416 67.509 2.136 67.509 3.024C67.509 3.96 67.185 4.74 66.537 5.364C65.913 5.964 65.073 6.264 64.017 6.264Z'
                    fill='black'
                  />
                  <path
                    d='M83.4851 28.62C81.8531 28.62 80.4251 28.26 79.2011 27.54C77.9771 26.82 77.0171 25.728 76.3211 24.264C75.6491 22.776 75.3131 20.904 75.3131 18.648C75.3131 16.368 75.6371 14.496 76.2851 13.032C76.9331 11.568 77.8691 10.476 79.0931 9.756C80.3171 9.036 81.7811 8.676 83.4851 8.676C85.3091 8.676 86.9411 9.096 88.3811 9.936C89.8451 10.752 90.9971 11.904 91.8371 13.392C92.7011 14.88 93.1331 16.632 93.1331 18.648C93.1331 20.688 92.7011 22.452 91.8371 23.94C90.9971 25.428 89.8451 26.58 88.3811 27.396C86.9411 28.212 85.3091 28.62 83.4851 28.62ZM72.0371 35.316V8.964H77.4011V12.924L77.2931 18.684L77.6531 24.408V35.316H72.0371ZM82.5131 24.012C83.4491 24.012 84.2771 23.796 84.9971 23.364C85.7411 22.932 86.3291 22.32 86.7611 21.528C87.2171 20.712 87.4451 19.752 87.4451 18.648C87.4451 17.52 87.2171 16.56 86.7611 15.768C86.3291 14.976 85.7411 14.364 84.9971 13.932C84.2771 13.5 83.4491 13.284 82.5131 13.284C81.5771 13.284 80.7371 13.5 79.9931 13.932C79.2491 14.364 78.6611 14.976 78.2291 15.768C77.7971 16.56 77.5811 17.52 77.5811 18.648C77.5811 19.752 77.7971 20.712 78.2291 21.528C78.6611 22.32 79.2491 22.932 79.9931 23.364C80.7371 23.796 81.5771 24.012 82.5131 24.012Z'
                    fill='black'
                  />
                  <path
                    d='M104.813 28.62C102.533 28.62 100.757 28.044 99.4846 26.892C98.2126 25.716 97.5766 23.976 97.5766 21.672V4.68H103.193V21.6C103.193 22.416 103.409 23.052 103.841 23.508C104.273 23.94 104.861 24.156 105.605 24.156C106.493 24.156 107.249 23.916 107.873 23.436L109.385 27.396C108.809 27.804 108.113 28.116 107.297 28.332C106.505 28.524 105.677 28.62 104.813 28.62ZM94.5886 13.716V9.396H108.017V13.716H94.5886Z'
                    fill='black'
                  />
                  <path
                    d='M47.0295 53.764C45.0135 53.764 43.0815 53.5 41.2335 52.972C39.3855 52.42 37.8975 51.712 36.7695 50.848L38.7495 46.456C39.8295 47.224 41.1015 47.86 42.5655 48.364C44.0535 48.844 45.5535 49.084 47.0655 49.084C48.2175 49.084 49.1415 48.976 49.8375 48.76C50.5575 48.52 51.0855 48.196 51.4215 47.788C51.7575 47.38 51.9255 46.912 51.9255 46.384C51.9255 45.712 51.6615 45.184 51.1335 44.8C50.6055 44.392 49.9095 44.068 49.0455 43.828C48.1815 43.564 47.2215 43.324 46.1655 43.108C45.1335 42.868 44.0895 42.58 43.0335 42.244C42.0015 41.908 41.0535 41.476 40.1895 40.948C39.3255 40.42 38.6175 39.724 38.0655 38.86C37.5375 37.996 37.2735 36.892 37.2735 35.548C37.2735 34.108 37.6575 32.8 38.4255 31.624C39.2175 30.424 40.3935 29.476 41.9535 28.78C43.5375 28.06 45.5175 27.7 47.8935 27.7C49.4775 27.7 51.0375 27.892 52.5735 28.276C54.1095 28.636 55.4655 29.188 56.6415 29.932L54.8415 34.36C53.6655 33.688 52.4895 33.196 51.3135 32.884C50.1375 32.548 48.9855 32.38 47.8575 32.38C46.7295 32.38 45.8055 32.512 45.0855 32.776C44.3655 33.04 43.8495 33.388 43.5375 33.82C43.2255 34.228 43.0695 34.708 43.0695 35.26C43.0695 35.908 43.3335 36.436 43.8615 36.844C44.3895 37.228 45.0855 37.54 45.9495 37.78C46.8135 38.02 47.7615 38.26 48.7935 38.5C49.8495 38.74 50.8935 39.016 51.9255 39.328C52.9815 39.64 53.9415 40.06 54.8055 40.588C55.6695 41.116 56.3655 41.812 56.8935 42.676C57.4455 43.54 57.7215 44.632 57.7215 45.952C57.7215 47.368 57.3255 48.664 56.5335 49.84C55.7415 51.016 54.5535 51.964 52.9695 52.684C51.4095 53.404 49.4295 53.764 47.0295 53.764Z'
                    fill='black'
                  />
                  <path
                    d='M73.0826 33.676C74.6186 33.676 75.9866 33.988 77.1866 34.612C78.4106 35.212 79.3706 36.148 80.0666 37.42C80.7626 38.668 81.1106 40.276 81.1106 42.244V53.332H75.4946V43.108C75.4946 41.548 75.1466 40.396 74.4506 39.652C73.7786 38.908 72.8186 38.536 71.5706 38.536C70.6826 38.536 69.8786 38.728 69.1586 39.112C68.4626 39.472 67.9106 40.036 67.5026 40.804C67.1186 41.572 66.9266 42.556 66.9266 43.756V53.332H61.3106V26.62H66.9266V39.328L65.6666 37.708C66.3626 36.412 67.3586 35.416 68.6546 34.72C69.9506 34.024 71.4266 33.676 73.0826 33.676Z'
                    fill='black'
                  />
                  <path
                    d='M95.5578 53.62C93.4938 53.62 91.6578 53.188 90.0498 52.324C88.4658 51.46 87.2058 50.284 86.2698 48.796C85.3578 47.284 84.9018 45.568 84.9018 43.648C84.9018 41.704 85.3578 39.988 86.2698 38.5C87.2058 36.988 88.4658 35.812 90.0498 34.972C91.6578 34.108 93.4938 33.676 95.5578 33.676C97.5978 33.676 99.4218 34.108 101.03 34.972C102.638 35.812 103.898 36.976 104.81 38.464C105.722 39.952 106.178 41.68 106.178 43.648C106.178 45.568 105.722 47.284 104.81 48.796C103.898 50.284 102.638 51.46 101.03 52.324C99.4218 53.188 97.5978 53.62 95.5578 53.62ZM95.5578 49.012C96.4938 49.012 97.3338 48.796 98.0778 48.364C98.8218 47.932 99.4098 47.32 99.8418 46.528C100.274 45.712 100.49 44.752 100.49 43.648C100.49 42.52 100.274 41.56 99.8418 40.768C99.4098 39.976 98.8218 39.364 98.0778 38.932C97.3338 38.5 96.4938 38.284 95.5578 38.284C94.6218 38.284 93.7818 38.5 93.0378 38.932C92.2938 39.364 91.6938 39.976 91.2378 40.768C90.8058 41.56 90.5898 42.52 90.5898 43.648C90.5898 44.752 90.8058 45.712 91.2378 46.528C91.6938 47.32 92.2938 47.932 93.0378 48.364C93.7818 48.796 94.6218 49.012 95.5578 49.012Z'
                    fill='black'
                  />
                  <path
                    d='M119.544 53.62C117.336 53.62 115.392 53.188 113.712 52.324C112.056 51.46 110.772 50.284 109.86 48.796C108.948 47.284 108.492 45.568 108.492 43.648C108.492 41.704 108.936 39.988 109.824 38.5C110.736 36.988 111.972 35.812 113.532 34.972C115.092 34.108 116.856 33.676 118.824 33.676C120.72 33.676 122.424 34.084 123.936 34.9C125.472 35.692 126.684 36.844 127.572 38.356C128.46 39.844 128.904 41.632 128.904 43.72C128.904 43.936 128.892 44.188 128.868 44.476C128.844 44.74 128.82 44.992 128.796 45.232H113.064V41.956H125.844L123.684 42.928C123.684 41.92 123.48 41.044 123.072 40.3C122.664 39.556 122.1 38.98 121.38 38.572C120.66 38.14 119.82 37.924 118.86 37.924C117.9 37.924 117.048 38.14 116.304 38.572C115.584 38.98 115.02 39.568 114.612 40.336C114.204 41.08 114 41.968 114 43V43.864C114 44.92 114.228 45.856 114.684 46.672C115.164 47.464 115.824 48.076 116.664 48.508C117.528 48.916 118.536 49.12 119.688 49.12C120.72 49.12 121.62 48.964 122.388 48.652C123.18 48.34 123.9 47.872 124.548 47.248L127.536 50.488C126.648 51.496 125.532 52.276 124.188 52.828C122.844 53.356 121.296 53.62 119.544 53.62Z'
                    fill='black'
                  />
                  <path
                    d='M139.159 53.62C137.503 53.62 135.907 53.428 134.371 53.044C132.859 52.636 131.659 52.132 130.771 51.532L132.643 47.5C133.531 48.052 134.575 48.508 135.775 48.868C136.999 49.204 138.199 49.372 139.375 49.372C140.671 49.372 141.583 49.216 142.111 48.904C142.663 48.592 142.939 48.16 142.939 47.608C142.939 47.152 142.723 46.816 142.291 46.6C141.883 46.36 141.331 46.18 140.635 46.06C139.939 45.94 139.171 45.82 138.331 45.7C137.515 45.58 136.687 45.424 135.847 45.232C135.007 45.016 134.239 44.704 133.543 44.296C132.847 43.888 132.283 43.336 131.851 42.64C131.443 41.944 131.239 41.044 131.239 39.94C131.239 38.716 131.587 37.636 132.283 36.7C133.003 35.764 134.035 35.032 135.379 34.504C136.723 33.952 138.331 33.676 140.203 33.676C141.523 33.676 142.867 33.82 144.235 34.108C145.603 34.396 146.743 34.816 147.655 35.368L145.783 39.364C144.847 38.812 143.899 38.44 142.939 38.248C142.003 38.032 141.091 37.924 140.203 37.924C138.955 37.924 138.043 38.092 137.467 38.428C136.891 38.764 136.603 39.196 136.603 39.724C136.603 40.204 136.807 40.564 137.215 40.804C137.647 41.044 138.211 41.236 138.907 41.38C139.603 41.524 140.359 41.656 141.175 41.776C142.015 41.872 142.855 42.028 143.695 42.244C144.535 42.46 145.291 42.772 145.963 43.18C146.659 43.564 147.223 44.104 147.655 44.8C148.087 45.472 148.303 46.36 148.303 47.464C148.303 48.664 147.943 49.732 147.223 50.668C146.503 51.58 145.459 52.3 144.091 52.828C142.747 53.356 141.103 53.62 139.159 53.62Z'
                    fill='black'
                  />
                </svg>
              </Link>
              <div className='flex gap-3'>
                <svg
                  width='32'
                  height='36'
                  viewBox='0 0 36 36'
                  fill='none'
                  xmlns='http://www.w3.org/2000/svg'
                  onClick={() => setIsOpened(!isOpened)}
                  className='cursor-pointer'
                >
                  <path
                    d='M33.8 36L20.65 22.85C19.65 23.7167 18.4833 24.3917 17.15 24.875C15.8167 25.3583 14.4 25.6 12.9 25.6C9.3 25.6 6.25 24.35 3.75 21.85C1.25 19.35 0 16.3333 0 12.8C0 9.26667 1.25 6.25 3.75 3.75C6.25 1.25 9.28333 0 12.85 0C16.3833 0 19.3917 1.25 21.875 3.75C24.3583 6.25 25.6 9.26667 25.6 12.8C25.6 14.2333 25.3667 15.6167 24.9 16.95C24.4333 18.2833 23.7333 19.5333 22.8 20.7L36 33.8L33.8 36ZM12.85 22.6C15.55 22.6 17.85 21.6417 19.75 19.725C21.65 17.8083 22.6 15.5 22.6 12.8C22.6 10.1 21.65 7.79167 19.75 5.875C17.85 3.95833 15.55 3 12.85 3C10.1167 3 7.79167 3.95833 5.875 5.875C3.95833 7.79167 3 10.1 3 12.8C3 15.5 3.95833 17.8083 5.875 19.725C7.79167 21.6417 10.1167 22.6 12.85 22.6V22.6Z'
                    fill='black'
                  />
                </svg>
                <svg
                  width='32'
                  height='32'
                  viewBox='0 0 36 24'
                  fill='none'
                  xmlns='http://www.w3.org/2000/svg'
                >
                  <path
                    d='M0 24V21H36V24H0ZM0 13.5V10.5H36V13.5H0ZM0 3V0H36V3H0Z'
                    fill='black'
                  />
                </svg>
              </div>
            </motion.div>
          )}
        </nav>
        {value !== '' && value && searchPhrase && isOpened && (
          <div className='absolute z-50'>
            <SearchForShoes
              pageNumber={1}
              pageSize={3}
              searchPhrase={value}
              key={searchPhrase}
            />
          </div>
        )}
      </div>
    </AnimatePresence>
  );
};

export default Navbar;
