import { create } from 'zustand';

interface ShoewReviewsStore {
  isOpened: boolean;
  setIsOpened: (isOpened: boolean) => void;
}

const useShoewReviewsStore = create<ShoewReviewsStore>(set => ({
  isOpened: false,
  setIsOpened: isOpened => set(() => ({ isOpened: isOpened })),
}));

export default useShoewReviewsStore;
