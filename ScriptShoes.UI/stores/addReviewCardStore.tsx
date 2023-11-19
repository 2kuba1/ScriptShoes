import { create } from 'zustand';

interface AddReviewCardStore {
  isOpened: boolean;
  setIsOpened: (isOpened: boolean) => void;
}

const useAddReviewCardStore = create<AddReviewCardStore>(set => ({
  isOpened: true,
  setIsOpened: isOpened => set(() => ({ isOpened: isOpened })),
}));

export default useAddReviewCardStore;
