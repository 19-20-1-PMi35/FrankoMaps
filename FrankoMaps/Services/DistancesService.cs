using DataAccess.Repositories;
using AutoMapper;
using DataAccess.Entities;
using System.Collections.Generic;
using FrankoMaps.Models;
using System.Linq;
using FrankoMaps.Algorithms;

namespace FrankoMaps.Services
{
    public class DistancesService
    {
        private readonly DistanceRepository repository;
        private readonly PointRepository _pointRepository;
        private readonly IMapper _mapper;
        private double [,] graph;
        private DijkstrasAlgorithm dijkstras;
        private Dictionary<int, int> indexes;

        public DistancesService(DistanceRepository distanceRepository, IMapper mapper, PointRepository pointRepository)
        {
            repository = distanceRepository;
            _mapper = mapper;
            _pointRepository = pointRepository;
            
            CreateGraph();
            dijkstras = new DijkstrasAlgorithm(graph);
        }

        public List<DistanceViewModel> GetDistances()
        {
            List<Distance> distances = repository.GetItems();
            List<DistanceViewModel> distanceViewModels = _mapper.Map<List<DistanceViewModel>>(distances);
            return distanceViewModels;
        }
        public int[] GetTheShortestPath(int fromPId, int toPId)
        {
            int from = indexes.FirstOrDefault(k => k.Value == fromPId).Key;
            int to = indexes.FirstOrDefault(k => k.Value == toPId).Key;

            dijkstras.DijkstraAlgo(from);
            List<int> path = dijkstras.GetPathForVertex(to);

            int[] pointsId = new int[path.Count];
            for(int i = 0; i < path.Count; ++i)
            {
                pointsId[i] = indexes[path[i]];
            }

            return pointsId;
        }
        private void CreateGraph()
        {
            List<Distance> distances = repository.GetItems();
            List<Point> points = _pointRepository.GetItems();

            List<DistanceViewModel> distanceViewModels = _mapper.Map<List<DistanceViewModel>>(distances);
            List<PointViewModel> pointViewModels = _mapper.Map<List<PointViewModel>>(points);

            List<int> pointsId = pointViewModels.Select(p => p.Id).ToList();

            indexes = new Dictionary<int, int>();
            
            for(int i = 0; i < pointsId.Count; ++i)
            {
                indexes.Add(i, pointsId[i]);
            }

            int n = pointViewModels.Count;

            graph = new double[n, n];

            foreach (DistanceViewModel distance in distanceViewModels)
            {
                int i = indexes.FirstOrDefault(k => k.Value == distance.FromPointId).Key;
                int j = indexes.FirstOrDefault(k => k.Value == distance.ToPointId).Key;

                graph[i, j] = distance.Weight;
                graph[j, i] = distance.Weight;
            }
        } 
    }
}