using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageList.Commons
{
    public class PageCollection<T> where T : class
    {
        //Basic Property
        private int _recordPerPage;
        private IEnumerable<T> _list;
        private int _pageSize;

        //UI Property
        private int _pageActive;
        private readonly int _maxPageShow = 8;
        private int _pageStart;
        private int _pageEnd;

        public PageCollection(IEnumerable<T> list, int recordPerPage, int pageActive = 1, int maxPageShow=8)
        {
            _list = list;
            RecordPerPage = recordPerPage;
            PageActive = pageActive;
            _maxPageShow = maxPageShow;
        }

        public int RecordPerPage {
            get { return _recordPerPage; }

            set
            {
                if (value < 1)
                {
                    throw new InvalidOperationException("Record per Page should be greater then 0");
                }
                _recordPerPage = value;
                _pageSize = (_list.Count() / RecordPerPage)+(_list.Count()%RecordPerPage>0?1:0);
            }
        }

        public int PageSize { get { return _pageSize; }}

        public int PageActive {
            get
            {
                if (_pageActive < 1)
                    _pageActive = 1;
                return _pageActive;
            }
            set
            {
                if (value < 1)
                    throw new InvalidOperationException("Page active should be greater than 0");
                if (value > PageSize)
                    throw new InvalidOperationException("Page active out of range");
                _pageActive = value;
                _pageStart = (((_pageActive - 1) / _maxPageShow) * _maxPageShow) + 1;
                _pageEnd = _pageStart - 1 + _maxPageShow;
                var middle = _maxPageShow / 2 + (_maxPageShow%2);
                if (PageActive % _maxPageShow > middle)
                {
                    _pageStart += (PageActive % _maxPageShow - middle);
                    _pageEnd += (PageActive % _maxPageShow - middle);
                }
                else if (PageActive % _maxPageShow == 0)//8,16,
                {
                    _pageStart += middle;
                    _pageEnd += middle;
                }
                else if (PageActive / _maxPageShow > 0)
                {
                    _pageStart -= middle-(PageActive % _maxPageShow);
                    _pageEnd -= middle - (PageActive % _maxPageShow);
                }
                if (PageSize < _pageEnd)
                {
                    _pageEnd = PageSize;
                    _pageStart = _pageEnd - _maxPageShow+1 > 0 ? _pageEnd - _maxPageShow+1 : 1;

                }
            }
        }

        public int PageStart { get { return _pageStart; } }

        public int PageEnd { get { return _pageEnd; } }

        //Method
        public List<T> GetPage(int page)
        {
            return _list.Skip((page - 1) * _recordPerPage).Take(_recordPerPage).ToList();
        }

        public List<T> GetNow()
        {
            return GetPage(_pageActive);
        }

        public List<T> GetLast()
        {
            return GetPage(_pageSize);
        }

        public string GeneratePager()
        {
            string _ui="<<"+(_pageActive>1?" <":"");
            for (int i = _pageStart; i <= _pageEnd; i++) {
                _ui += " " + i.ToString() + ((_pageActive==i)?"a ":" ");
            }
            return _ui + (_pageActive < _pageSize ? "> " : "") + ">>";
        }
    }
}
